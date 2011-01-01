﻿using System;
using Machine.Specifications;
using PageTypeBuilder.Specs.Helpers.TypeBuildingDsl;

namespace PageTypeBuilder.Specs.Synchronization.Validation
{
    [Subject("Synchronization")]
    public class when_a_page_type_property_has_an_invalid_type_specified_in_the_attribute
        : SynchronizationSpecs
    {
        static Exception thrownException;
        static string pageTypeName = "NameOfThePropertysPageType";
        static string propertyName = "ThePropertysName";

        Establish context = () => SyncContext.AddPageTypeClassToAppDomain(type =>
            {
                type.Name = pageTypeName;
                type.AddProperty(property =>
                    {
                        property.Name = propertyName;
                        property.Type = typeof (string);
                        property.AddAttributeTemplate(
                            new PageTypePropertyAttribute
                                {
                                   Type = typeof (SomeClassThatDefinitelyIsNotAProperty) 
                                });
                    });
            });

        Because of = () =>
            thrownException = Catch.Exception(
                () => SyncContext.PageTypeSynchronizer.SynchronizePageTypes());

        It should_throw_an_Exception = () =>
            thrownException.ShouldNotBeNull();

        It should_throw_a_PageTypeBuilderException = () =>
            thrownException.ShouldBeOfType<PageTypeBuilderException>();

        It should_throw_an_Exception_whose_Message_should_contain_the_propertys_name = () =>
            thrownException.Message.ShouldContain(propertyName);

        It should_throw_an_Exception_whose_Message_should_contain_the_page_type_class_name = () =>
            thrownException.Message.ShouldContain(pageTypeName);

        public class SomeClassThatDefinitelyIsNotAProperty {}
    }
}