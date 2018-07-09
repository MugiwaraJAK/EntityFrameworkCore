﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.EntityFrameworkCore.Cosmos.Sql.TestUtilities
{
    public class CosmosSqlTestStoreFactory : ITestStoreFactory
    {
        public static CosmosSqlTestStoreFactory Instance { get; } = new CosmosSqlTestStoreFactory();

        protected CosmosSqlTestStoreFactory()
        {
        }

        public IServiceCollection AddProviderServices(IServiceCollection serviceCollection)
            => serviceCollection.AddEntityFrameworkCosmosSql().AddSingleton<TestStoreIndex>();

        public TestStore Create(string storeName) => CosmosSqlTestStore.Create(storeName);

        public virtual TestStore GetOrCreate(string storeName) => CosmosSqlTestStore.GetOrCreate(storeName);
    }
}