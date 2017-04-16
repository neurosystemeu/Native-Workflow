using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class ModelDescriptor : JsonObject
    {
        public DataSource ChildrenDataSource
        {
            get;
            set;
        }

        public string ChildrenMember
        {
            get;
            set;
        }

        public IList<ModelFieldDescriptor> Fields
        {
            get;
            private set;
        }

        public string HasChildrenMember
        {
            get;
            set;
        }

        public IDataKey Id
        {
            get;
            set;
        }

        //public ModelDescriptor(Type modelType)
        //{
        //    ModelMetadata metadataForType = ModelMetadataProviders.Current.GetMetadataForType(null, modelType);
        //    this.Fields = this.Translate(metadataForType);
        //}

        public ModelFieldDescriptor AddDescriptor(string member)
        {
            ModelFieldDescriptor modelFieldDescriptor = this.Fields.FirstOrDefault<ModelFieldDescriptor>((ModelFieldDescriptor f) => f.Member == member);
            if (modelFieldDescriptor != null)
            {
                return modelFieldDescriptor;
            }
            modelFieldDescriptor = new ModelFieldDescriptor()
            {
                Member = member
            };
            this.Fields.Add(modelFieldDescriptor);
            return modelFieldDescriptor;
        }

        private object CreateDataItem(Type modelType)
        {
            if (modelType == typeof(DataRowView))
            {
                return (new DataTable()).DefaultView.AddNew();
            }
            if (modelType == typeof(DataRow))
            {
                return (new DataTable()).NewRow();
            }
            return Activator.CreateInstance(modelType);
        }

        //protected override void Serialize(IDictionary<string, object> json)
        //{
        //    if (this.Id != null)
        //    {
        //        json["id"] = this.Id.Name;
        //    }
        //    FluentDictionary.For(json).Add<string>("hasChildren", this.HasChildrenMember, new Func<bool>(this.HasChildrenMember.HasValue));
        //    if (this.ChildrenDataSource != null)
        //    {
        //        json["children"] = this.ChildrenDataSource.ToJson();
        //    }
        //    else if (this.ChildrenMember.HasValue())
        //    {
        //        json["children"] = this.ChildrenMember;
        //    }
        //    if (this.Fields.Count > 0)
        //    {
        //        Dictionary<string, object> strs1 = new Dictionary<string, object>();
        //        json["fields"] = strs1;
        //        this.Fields.Each<ModelFieldDescriptor>((ModelFieldDescriptor prop) => {
        //            Dictionary<string, object> strs = new Dictionary<string, object>();
        //            strs1[prop.Member] = strs;
        //            if (!prop.IsEditable)
        //            {
        //                strs["editable"] = false;
        //            }
        //            strs["type"] = prop.MemberType.ToJavaScriptType().ToLowerInvariant();
        //            if (prop.MemberType.IsNullableType() || prop.DefaultValue != null)
        //            {
        //                object defaultValue = prop.DefaultValue;
        //                if (prop.MemberType.GetNonNullableType().IsEnum && defaultValue is Enum)
        //                {
        //                    defaultValue = Convert.ChangeType(defaultValue, Enum.GetUnderlyingType(prop.MemberType.GetNonNullableType()));
        //                }
        //                strs["defaultValue"] = defaultValue;
        //            }
        //            if (!string.IsNullOrEmpty(prop.From))
        //            {
        //                strs["from"] = prop.From;
        //            }
        //            if (prop.IsNullable)
        //            {
        //                strs["nullable"] = prop.IsNullable;
        //            }
        //            if (prop.Parse.HasValue())
        //            {
        //                strs["parse"] = prop.Parse;
        //            }
        //        });
        //    }
        //}

        //private IList<ModelFieldDescriptor> Translate(ModelMetadata metadata)
        //{
        //    return (
        //        from p in metadata.Properties
        //        select new ModelFieldDescriptor()
        //        {
        //            Member = p.PropertyName,
        //            MemberType = p.ModelType,
        //            IsEditable = !p.IsReadOnly
        //        }).ToList<ModelFieldDescriptor>();
        //}
    }
}