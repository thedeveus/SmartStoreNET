﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using SmartStore.Core.Domain.Media;
using SmartStore.Core.Security;
using SmartStore.Services.Media;
using SmartStore.Web.Framework.WebApi;
using SmartStore.Web.Framework.WebApi.OData;
using SmartStore.Web.Framework.WebApi.Security;

namespace SmartStore.WebApi.Controllers.OData
{
    public class DownloadsController : WebApiEntityController<Download, IDownloadService>
	{
		[WebApiQueryable]
		[WebApiAuthenticate(Permission = Permissions.Media.Download.Read)]
		public IQueryable<Download> Get()
		{
			return GetEntitySet();
		}

		[WebApiQueryable]
        [WebApiAuthenticate(Permission = Permissions.Media.Download.Read)]
        public SingleResult<Download> Get(int key)
		{
			return GetSingleResult(key);
		}

		[WebApiAuthenticate(Permission = Permissions.Media.Download.Read)]
		public IHttpActionResult GetProperty(int key, string propertyName)
		{
			return GetPropertyValue(key, propertyName);
		}

		[WebApiAuthenticate(Permission = Permissions.Media.Download.Create)]
		public IHttpActionResult Post(Download entity)
		{
			var result = Insert(entity, () => Service.InsertDownload(entity));
			return result;
		}

		[WebApiAuthenticate(Permission = Permissions.Media.Download.Update)]
		public async Task<IHttpActionResult> Put(int key, Download entity)
		{
			var result = await UpdateAsync(entity, key, () => Service.UpdateDownload(entity));
			return result;
		}

		[WebApiAuthenticate(Permission = Permissions.Media.Download.Update)]
		public async Task<IHttpActionResult> Patch(int key, Delta<Download> model)
		{
			var result = await PartiallyUpdateAsync(key, model, entity => Service.UpdateDownload(entity));
			return result;
		}

		[WebApiAuthenticate(Permission = Permissions.Media.Download.Delete)]
		public async Task<IHttpActionResult> Delete(int key)
		{
			var result = await DeleteAsync(key, entity => Service.DeleteDownload(entity));
			return result;
		}
	}
}
