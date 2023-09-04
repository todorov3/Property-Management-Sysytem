using Dapper;
using System.Data;
using PropertyManagementSystem.Data;
using PropertyManagementSystem.Models;
using PropertyManagementSystem.Repositories.Contracts;

namespace PropertyManagementSystem.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DapperContext _dapperContext;

        public PropertyRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<Property> GetPropertyById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<Property>(
                                                                        "spPropertyGetById", 
                                                                        connection, 
                                                                        commandType: 
                                                                        CommandType.StoredProcedure);
            }
        }

        public Task<List<Property>> GetPropertyByLandlordId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Property>> GetAllProperties()
        {
            using var connection = _dapperContext.CreateConnection();
            {
                return (await connection.QueryAsync<Property>(
                                                        "spPropertyGetAll", 
                                                        connection, 
                                                        commandType: 
                                                        CommandType.StoredProcedure))
                                                        .ToList();
            }
        }

        public Task<Property> CreateProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public Task<Property> UpdateProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public async Task<Property> DeleteProperty(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _dapperContext.CreateConnection();
            {
                return await connection.QuerySingleOrDefaultAsync<Property>(
                                                                        "spPropertyDelete", 
                                                                        parameters, 
                                                                        commandType: 
                                                                        CommandType.StoredProcedure);
            }
        }
    }
}
