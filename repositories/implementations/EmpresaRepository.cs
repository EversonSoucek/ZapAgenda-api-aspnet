using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.Dtos.Empresa;
using ZapAgenda_api_aspnet.Exceptions;
using ZapAgenda_api_aspnet.interfaces;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class EmpresaRepository :Repository<Empresa>, IEmpresaRepository
    {
        private readonly IIbgeService _ibgeservice;
        public EmpresaRepository(CoreDBContext context, IIbgeService ibgeService ) : base(context)
        {
            _ibgeservice = ibgeService;
        }

        public new async Task<Empresa> CreateAsync(Empresa empresaModel)
        {
            var cidadeExiste = await _ibgeservice.SeMunicipioExiste(empresaModel.NomeMunicipio,empresaModel.Sigla);
            if (!cidadeExiste) {
                throw new CustomBadRequest(
                    title:"Cidade não pertence a esse estado",
                    detail: $"Não existe cidade: {empresaModel.NomeMunicipio} no estado: {empresaModel.Sigla}"
                );
            }
            await _context.Empresa.AddAsync(empresaModel);
            await _context.SaveChangesAsync();
            return empresaModel;
        }

        public async Task<Empresa?> UpdateAsync(UpdateEmpresaDto empresaDto, int id)
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync(empresa => empresa.IdEmpresa ==id);
            if(empresa == null) {
                return null;
            }
            // todo: Ver se a melhor prática é jogar isso aqui em um mapper
                empresa.Cnpj = empresaDto.Cnpj;
                empresa.NomeFantasia = empresaDto.NomeFantasia;
                empresa.RazaoSocial = empresaDto.RazaoSocial;
                empresa.TipoEmpresa = empresaDto.TipoEmpresa;
                empresa.Email = empresaDto.Email;
                empresa.Telefone = empresaDto.Telefone;


                await _context.SaveChangesAsync();
                return empresa;
        }
    }
}