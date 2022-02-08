using System;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Attributes
{
    public class CustomPermissionAttribute : Attribute
    {
        public string Permission { get; }
        public CustomPermissionAttribute(string permission)
        {
            Permission = permission;
        }

    }

}
