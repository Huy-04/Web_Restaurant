using Inventory.Application.DTOs.Responses.Unit;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping.UnitMapExtension;
using MediatR;

namespace Inventory.Application.Modules.Unit.Queries.GetAllUnit
{
    public sealed class GetAllUnitQHandler : IRequestHandler<GetAllUnitQuery, IEnumerable<UnitResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllUnitQHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<UnitResponse>> Handle(GetAllUnitQuery query, CancellationToken token)
        {
            var list = await _uow.UnitRepo.GetAllAsync();
            return list.Select(u => u.ToUnitToResponse());
        }
    }
}