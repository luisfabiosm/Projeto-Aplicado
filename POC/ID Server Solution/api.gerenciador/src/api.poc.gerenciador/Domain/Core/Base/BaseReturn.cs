using Domain.Core.Enums;
using System.Net;


namespace Domain.Core.Base
{

    public record BaseReturn
    {
        public object? Body;
        public BaseError? Error;
        public HttpStatusCode StatusCode = HttpStatusCode.OK;

        public BaseReturn()
        {

        }
        public BaseReturn(object result, EnumReturnType type = EnumReturnType.SUCCESS)
        {

            StatusCode = type switch
            {
                EnumReturnType.SYSTEM => HttpStatusCode.InternalServerError,
                EnumReturnType.BUSINESS => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.OK
            };

            if (result is not null && result is Exception messageResult)
            {
                Error = new()
                {
                    code = StatusCode.ToString(),
                    message = messageResult.Message,
                    info = messageResult.StackTrace ?? "",
                };
            }

            Body = result is not Exception ? result : null;
        }


        public IResult GetResponse()
        {
            if (StatusCode is HttpStatusCode.OK) return Results.Ok(Body);
            return Results.Json(Error, statusCode: (int)StatusCode);
        }


        public IResult GetResponse(object successObject)
        {
            if (StatusCode is HttpStatusCode.OK) return Results.Ok(successObject);
            return Results.Json(Error, statusCode: (int)StatusCode);
        }



    }

}