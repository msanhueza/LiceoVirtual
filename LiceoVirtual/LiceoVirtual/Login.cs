
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Security.Cryptography;

namespace LiceoVirtual
{
	[Activity (Label = "Login")]			
	public class Login : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Login);

			Button btnLogin = FindViewById<Button> (Resource.Id.btnLogin);

			btnLogin.Click += delegate {
				validarLogin();
			};
		}

		/// <summary>
		/// Valida si los datos del formulario son validos
		/// </summary>
		private void validarLogin(){

			EditText edtRut = FindViewById<EditText> (Resource.Id.edtRut);
			EditText edtContrasena = FindViewById<EditText> (Resource.Id.edtContrasena);
			CheckBox cbxRecordarContrasena = FindViewById<CheckBox> (Resource.Id.cbxRecordarContrasena);


			string rut = edtRut.Text;
			string pass = edtContrasena.Text;

			if (!validarRut (rut)) {
				edtRut.RequestFocus();
				edtRut.SetError ("Debe ingresar un rut válido", null);
			}

			if (pass.Length == 0) {
				edtContrasena.RequestFocus();
				edtContrasena.SetError ("Debe ingresar una contraseña", null);
			}

		}

		/// <summary>
		/// Se encarga de validar un rut en Chile
		/// </summary>
		/// <returns><c>true</c>, Si el rut es valido, <c>false</c> Si no lo es.</returns>
		/// <param name="rut">RUT sin puntos ni guion</param>
		private bool validarRut(string rut ) {

			bool validacion = false;
			try {
				rut =  rut.ToUpper();
				rut = rut.Replace(".", "");
				rut = rut.Replace("-", "");
				int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

				char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

				int m = 0, s = 1;
				for (; rutAux != 0; rutAux /= 10) {
					s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
				}
				if (dv == (char) (s != 0 ? s + 47 : 75)) {
					validacion = true;
				}
			} catch (Exception) {
			}
			return validacion;
		}

		/// <summary>
		/// Se encarga de convertir un string a encriptado md5
		/// </summary>
		/// <returns>El string a md5</returns>
		/// <param name="input">Es el string que se quiere convertir a md5</param>
		private string getMd5Hash(string input)
		{
			// crea la instancia del objeto md5
			MD5 md5Hasher = MD5.Create();

			// convierte el string a un array
			byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

			// crea un nuevo constructor de string
			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
				
			return sBuilder.ToString();
		}
	}
}

