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
        public async Task<Request> CreateRequest(Request requestDto)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TenandId", requestDto.TenantId, DbType.Int32);
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

        public async Task<Request> GetRequestById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<Request>(
                                                                        "spRequestGetById", 
                                                                        connection, 
                                                                        commandType: 
                                                                        CommandType.StoredProcedure);
            }
        }

        public async Task<List<Request>> GetRequestsByTenandId(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TenandId", id, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<Request>(
                                                        "spRequestGetByTenandId", 
                                                        connection, 
                                                        commandType: 
                                                        CommandType.StoredProcedure))
                                                        .ToList();
            }
        }

        public async Task<List<Request>> GetRequestsByPropertyId(int propertyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PropertyId", propertyId, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<Request>(
                                                        "spRequestGetByPropertyId", 
                                                        connection, 
                                                        commandType: 
                                                        CommandType.StoredProcedure))
                                                        .ToList();
            }
        }

        public async Task AcceptRequest(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                                            "spRequestAccept", 
                                            connection, 
                                            commandType: 
                                            CommandType.StoredProcedure);
            }
        }

        public async Task DeclineRequest(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using var connection = _dapperContext.CreateConnection();
            {
                await connection.ExecuteAsync(
                                            "spRequestDecline", 
                                            connection, 
                                            commandType: 
                                            CommandType.StoredProcedure);
            }
        }
    }
}
