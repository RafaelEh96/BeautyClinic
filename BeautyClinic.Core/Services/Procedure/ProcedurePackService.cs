using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Procedure;
using BeautyClinic.Core.Models.Procedure;

namespace BeautyClinic.Core.Services.Procedure;

public class ProcedurePackService : BaseService<ProcedurePack>, IProcedurePackService
{
    private readonly IProcedurePackProcedureRepository _packProcedureRepository;

    public ProcedurePackService(
        IProcedurePackRepository repository,
        IProcedurePackProcedureRepository packProcedureRepository,
        IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
        _packProcedureRepository = packProcedureRepository;
    }

    public async Task CreatePackWithProceduresAsync(ProcedurePack pack, IEnumerable<Guid> procedureIds)
    {
        await ExecuteInTransactionAsync(async () =>
        {
            await _repository.AddAsync(pack);

            foreach (var procedureId in procedureIds)
            {
                var packProcedure = new ProcedurePackProcedure
                {
                    ProcedurePackId = pack.Id,
                    ProcedureId = procedureId
                };
                await _packProcedureRepository.AddAsync(packProcedure);
            }
        });
    }

    public async Task UpdatePackWithProceduresAsync(ProcedurePack pack, IEnumerable<Guid> procedureIds)
    {
        await ExecuteInTransactionAsync(async () =>
        {
            _repository.Update(pack);

            await _packProcedureRepository.RemoveByPackIdAsync(pack.Id);

            foreach (var procedureId in procedureIds)
            {
                var packProcedure = new ProcedurePackProcedure
                {
                    ProcedurePackId = pack.Id,
                    ProcedureId = procedureId
                };
                await _packProcedureRepository.AddAsync(packProcedure);
            }
        });
    }
}
