namespace RhythmicRealm.Shared.Response
{
	public class Response<T>
	{
		public T Data { get; set; }
		public List<string> Errors { get; set; }
		public string Error { get; set; }
		public int StatusCode { get; set; }
		public bool IsSucceesed { get; set; }

		/// <summary>
		/// Bu metot; işlem başarılı olduğunda datayı ve http status code u dönmek için kullanılır.
		/// </summary>
		/// <param name="data">Geriye döndürülecek veri</param>
		/// <param name="statusCode">başarılı durumlarda dönen kodlar(200-201 vs)</param>
		/// <returns>Response<typeparamref name="T"/></returns>
		public static Response<T> Success(T data, int statusCode)
		{
			return new Response<T> { Data = data, StatusCode = statusCode, IsSucceesed = true };
		}



		/// <summary>
		/// Bu metot; işlem başarılı olduğunda http status code u dönemk için kullanılır.
		/// </summary>
		/// <param name="statusCode">başarılı durumlarda dönen kodlar(200-201 vs)</param>
		/// <returns>Response<typeparamref name="T"/></returns>
		public static Response<T> Success(int statusCode)
		{
			//Data=default(T)->işlem başarılı ancak dönecek veri yok.
			return new Response<T> { StatusCode = statusCode, Data = default(T), IsSucceesed = true };
		}



		/// <summary>
		/// Bu metot; işlem başarısız sonuçlandığında oluşan hata listesini dönmek için kullanılır.
		/// </summary>
		/// <param name="statusCode">başarısız durumlarda dönen kodlar(400-499/500-599)</param>
		/// <param name="errors">Hata Listesi</param>
		/// <returns>Response<typeparamref name="T"/></returns>
		public static Response<T> Fail(int statusCode, List<string> errors)
		{
			return new Response<T> { StatusCode = statusCode, Errors = errors, IsSucceesed = false };
		}



		/// <summary>
		/// Bu metot; işlem başarısız sonuçlandığında oluşan hatayı dönemk için kullanılır.
		/// </summary>
		/// <param name="statusCode">başarısız durumlarda dönen kodlar(400-499/500-599)</param>
		/// <param name="Error">Hata Metni</param>
		/// <returns>Response<typeparamref name="T"/></returns>
		public static Response<T> Fail(int statusCode, string Error)
		{
			return new Response<T> { StatusCode = statusCode, Error = Error, IsSucceesed = false };
		}

	}
}
