using Repositories1;

namespace usersWebService.Tests
{
    internal class WrapperRepository
    {
        private IWrapperRepository @object;

        public WrapperRepository(IWrapperRepository @object)
        {
            this.@object = @object;
        }
    }
}