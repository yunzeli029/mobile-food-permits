using MobileFoodPermits.Service.Models.Filters;

namespace MobileFoodPermits.Service.Models
{
    public class FilteredRequestDto
    {
        public FilteredRequestDto(ItemComparisonFilterDto filter)
        {
            Filter = filter;
        }

        public ItemComparisonFilterDto Filter { get; }
    }
}
