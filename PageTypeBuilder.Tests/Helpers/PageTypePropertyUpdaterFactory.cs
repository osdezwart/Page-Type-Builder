﻿using PageTypeBuilder.Abstractions;
using PageTypeBuilder.Synchronization;
using Rhino.Mocks;

namespace PageTypeBuilder.Tests.Helpers
{
    public class PageTypePropertyUpdaterFactory
    {
        public static PageTypePropertyUpdater Create()
        {
            return new PageTypePropertyUpdater(
                new PageDefinitionFactory(),
                new PageDefinitionTypeFactory(),
                new TabFactory());
        }

        public static PageTypePropertyUpdater PartialMock(MockRepository fakesRepository)
        {
            return fakesRepository.PartialMock<PageTypePropertyUpdater>(
                new PageDefinitionFactory(),
                new PageDefinitionTypeFactory(),
                new TabFactory());
        }

        public static PageTypePropertyUpdater Stub(MockRepository fakesRepository)
        {
            return fakesRepository.Stub<PageTypePropertyUpdater>(
                new PageDefinitionFactory(),
                new PageDefinitionTypeFactory(),
                new TabFactory());
        }
    }
}
