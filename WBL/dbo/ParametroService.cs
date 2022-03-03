using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL.dbo
{
    public interface IParametroService
    {
        Task<DBEntity> Create(ParametroEntity entity);
        Task<DBEntity> Delete(ParametroEntity entity);
        Task<IEnumerable<ParametroEntity>> Get();
        Task<ParametroEntity> GetById(ParametroEntity entity);
        Task<DBEntity> Update(ParametroEntity entity);
    }

    public class ParametroService : IParametroService
    {
        private readonly IDataAccess sql;

        public ParametroService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCRUD

        //Metodo Get
        public async Task<IEnumerable<ParametroEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ParametroEntity>("dbo.ParametroObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo GetById
        public async Task<ParametroEntity> GetById(ParametroEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ParametroEntity>("dbo.ParametroObtener", new { entity.Id_Parametro });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo Crear
        public async Task<DBEntity> Create(ParametroEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ParametroInsertar", new
                {
                    entity.Codigo
                  ,
                    entity.Descripcion
                  ,
                    entity.Valor
                  ,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo Actualizar
        public async Task<DBEntity> Update(ParametroEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ParametroActualizar", new
                {
                    entity.Id_Parametro
                  ,
                    entity.Codigo
                  ,
                    entity.Descripcion
                  ,
                    entity.Valor
                  ,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo Eliminar
        public async Task<DBEntity> Delete(ParametroEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ParametroEliminar", new
                {
                    entity.Id_Parametro

                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
