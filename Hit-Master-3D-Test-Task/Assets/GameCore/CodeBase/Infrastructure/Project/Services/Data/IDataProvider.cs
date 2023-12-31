﻿namespace GameCore.CodeBase.Infrastructure.Project.Services.Data
{
    public interface IDataProvider
    {
        public void Set<T>(T data) where T : IDataToProvide;

        public DataType Get<DataType>() where DataType : IDataToProvide;
    }
}