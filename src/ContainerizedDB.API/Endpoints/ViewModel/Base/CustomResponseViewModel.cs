﻿using System.Net;

namespace ContainerizedDB.API.Endpoints.ViewModel.Base
{
    public abstract class CustomResponseViewModelBase()
    {
        public string Mensagem { get; set; } = "Operação realizada com sucesso.";
        public bool Error { get; set; } = false;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }

    public class CustomResponseViewModel : CustomResponseViewModelBase
    {
    }

    public class CustomResponseViewModel<T>(T result) : CustomResponseViewModelBase
    {
        public T Result { get; set; } = result;
    }
}
