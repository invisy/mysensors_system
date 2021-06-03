using System;
using System.Collections.Generic;
using MySensors.ApplicationCore.Interfaces;

namespace MySensors.ApplicationCore.Mappers
{
    public abstract class GenericMapper<TEntity, TDto> : IMapper<TEntity, TDto>
    {
        public virtual TDto Map(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Map(TDto dto)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TDto> Map(IEnumerable<TEntity> entityList)
        {
            List<TDto> list = new List<TDto>();
            
            foreach (var entity in entityList)
                list.Add(Map(entity));

            return list.AsReadOnly();
        }

        public virtual IEnumerable<TEntity> Map(IEnumerable<TDto> dtoList)
        {
            List<TEntity> list = new List<TEntity>();
            
            foreach (var dto in dtoList)
                list.Add(Map(dto));

            return list.AsReadOnly();
        }
    }
}