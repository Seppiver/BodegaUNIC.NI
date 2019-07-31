using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bodega.Controllers
{
  
    public class UsuarioController : Controller
    {
       

        
        [Route("loginoffice365")]
        public async Task<IActionResult> logintoken([FromQuery]string code)
        {
             if (code != null )
            {

                //bool userID = await Office365.VerifyLogin(login.user, login.pass);
                bool userID = true;
                OAuth ex = new OAuth();
                var tokenr= await ex.tokinezoffice(code,"loginoffice365");
                var email = await ex.emailreader(tokenr);
                

                if (userID == false)
                {
                    return Unauthorized();
                }

                //Usuario u = _context.Usuario.Where(w => w.LoginEmail == email && w.RegAnulado == false).FirstOrDefault();
                LoginInfo u = null;

                try {

                    u = _context.LoginInfo.FromSql("SELECT * FROM seg.LoginInfo({0})", email).FirstOrDefault();
                } catch (Exception er)
                {
                    return Unauthorized();
                }


                if (u == null)
                {
                    return Unauthorized();
                }

             
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(u.Login, "Token"),
                            new[]
                            {
                        new Claim("ID",u.noInterno.ToString()),
                         new Claim("email",email),
                          new Claim("area", u.Area),
                             new Claim ("idarea", u.IdArea),
                               new Claim ("usuario", u.Login)
                            }
                            );

                var key = Encoding.ASCII.GetBytes("UN2I-SIF0A-Ord1ene8s");
                var singkeg = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key);
                var handler = new JwtSecurityTokenHandler();
                var token = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer= "nic.uni.edu.ni",
                    Audience= "nic.uni.edu.ni",
                    SigningCredentials= new SigningCredentials(singkeg,SecurityAlgorithms.HmacSha256),
                    Subject= identity,
                    Expires= DateTime.UtcNow.AddHours(2),
                   
                 });

                // Session["MyNumber"] = handler.WriteToken(token);
                HttpContext.Session.SetString("token", handler.WriteToken(token));
                HttpContext.Session.SetString("usuario", u.Login);
                HttpContext.Session.SetString("email", u.LoginEmail);
                HttpContext.Session.SetString("area", u.Area );

                return Redirect("../"); 
            }

            return BadRequest();
              
        }

    }
}
