using Dapper;
using PropertyManagementSystem.Data;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Models.DTO;
using PropertyManagementSystem.Repositories.Contracts;
using System.Data;

namespace PropertyManagementSystem.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DapperContext _dapperContext;
        public RequestRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<Request> CreateRequest(RequestCreateDto requestDto)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TenandId", requestDto.TenandId, DbType.Int32);
            parameters.Add("PropertyId", requestDto.PropertyId, DbType.Int32);
            parameters.Add("MoveIn", requestDto.MoveIn, DbType.Date);
            parameters.Add("MoveOut", requestDto.MoveOut, DbType.Date);

            using var connection = _dapperContext.CreateConnection();
            {
                var result = await connection.QuerySingleOrDefaultAsync<Request>(
                                                                            "spRequestCreate", 
                                                                            parameters, 
                                                                            commandType: 
                                                                            CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task DeleteRequest(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                                            "spRequestDelete", 
                                            parameters, 
                                            commandType: 
                                            CommandType.StoredProcedure);
            }
        }

        public Task<Request> GetRequestById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Request>> GetRequestByTenandId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Request>> GetRequestsByPropertyId(int propertyId)
        {
            throw new NotImplementedException();
        }
        public Task AcceptRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeclineRequest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
