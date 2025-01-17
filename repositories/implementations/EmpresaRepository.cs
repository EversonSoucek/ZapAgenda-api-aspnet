using FluentResults;
using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.Dtos.Empresa;
using ZapAgenda_api_aspnet.interfaces;
using ZapAgenda_api_aspnet.models;
using ZapAgenda_api_aspnet.repositories.generic;
using ZapAgenda_api_aspnet.repositories.interfaces;

namespace ZapAgenda_api_aspnet.repositories.implementations
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        private readonly IIbgeService _ibgeservice;
        public EmpresaRepository(CoreDBContext context, IIbgeService ibgeService) : base(context)
        {
            _ibgeservice = ibgeService;
        }

        public new async Task<Empresa> CreateAsync(Empresa empresaModel)
        {
            var cidadeExiste = await _ibgeservice.SeMunicipioExiste(empresaModel.NomeMunicipio, empresaModel.Sigla);
            if (!cidadeExiste.Value)
            {
                throw new ArgumentException($"Cidade {empresaModel.NomeMunicipio} de sigla: {empresaModel.Sigla} não existe");
            }
            await _context.Empresa.AddAsync(empresaModel);
            await _context.SaveChangesAsync();
            return empresaModel;
        }

        public async Task<Result<Empresa>> UpdateAsync(UpdateEmpresaDto empresaDto, int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return Result.Fail($"Não existe empresa de id: {id}");
            }

            var municipioExiste = await _ibgeservice.SeMunicipioExiste(empresaDto.NomeMunicipio,empresaDto.Sigla);
            if (!municipioExiste.Value) {
                throw new ArgumentException($"Cidade {empresaDto.NomeMunicipio} de sigla: {empresaDto.Sigla} não existe");
            }

            // todo: Ver se a melhor prática é jogar isso aqui em um mapper
            if(!string.IsNullOrEmpty(empresaDto.Cnpj)) {
                empresa.Cnpj = empresaDto.Cnpj;
            }
            if(!string.IsNullOrEmpty(empresaDto.NomeFantasia)) {
                empresa.NomeFantasia = empresaDto.NomeFantasia;
            }
            if(!string.IsNullOrEmpty(empresaDto.RazaoSocial)) {
                empresa.RazaoSocial = empresaDto.RazaoSocial;   
            }
            if(!string.IsNullOrEmpty(empresaDto.TipoEmpresa)) {
                empresa.TipoEmpresa = empresaDto.TipoEmpresa;   
            }
            if(!string.IsNullOrEmpty(empresaDto.Email)) {
                empresa.Email = empresaDto.Email;    
            }
            if(!string.IsNullOrEmpty(empresaDto.Telefone)) {
                empresa.Telefone = empresaDto.Telefone;    
            }
            if(!string.IsNullOrEmpty(empresaDto.Cep)) {
                empresa.Cep = empresaDto.Cep;    
            }
            if(!string.IsNullOrEmpty(empresaDto.NomeMunicipio)) {
                empresa.NomeMunicipio = empresaDto.NomeMunicipio;    
            }
            if(!string.IsNullOrEmpty(empresaDto.Sigla)) {
                empresa.Sigla = empresaDto.Sigla;
            }
            await _context.SaveChangesAsync();
            return Result.Ok(empresa);
        }
    }
}