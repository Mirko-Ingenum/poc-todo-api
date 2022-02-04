using System;
namespace Model.Results
{
	public class Response<T>
	{
        public Response(params ErrorResult[] errors)
        {
            this.Errors = new List<ErrorResult>(errors);
        }

        public Response(T data)
        {
            this.Data = data;
            this.Errors = new List<ErrorResult>();
        }

        public T Data { get; set; }

        public ICollection<ErrorResult> Errors { get; set; }

        public bool Success => this.Errors == null || !this.Errors.Any();
    }
}

