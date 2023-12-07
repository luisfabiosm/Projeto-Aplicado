﻿using System.Text.Json.Serialization;

namespace Domain.Models.Response
{
    public record BaseError
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? code { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? info { get; set; }

        public BaseError()
        {

        }
        public BaseError(string codigo, string mensagem, string info = null)
        {
            this.code = codigo;
            this.message = mensagem;
            this.info = info;
        }

        ~BaseError()
        {
            code = null;
            message = null;
            info = null;
        }
    }
}
