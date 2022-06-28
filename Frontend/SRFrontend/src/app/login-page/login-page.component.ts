import { Component, OnInit } from '@angular/core';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';
import { LoginInformacije } from '../_helpers/login-informacije';
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  txtUsername: any;
  txtPassword: any;
  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }
  btnLogin()/*Logiranje korisnika, smjestanje login informacija unutar autentifikacija helper i u slucaju uspjesnog slanje korisnika
  na home page. windows location reload je tu zbog osvjezavanja stranice radi mjenjanja vrijednosti buttona login/logout*/
   {
    let saljemo = {
      username: this.txtUsername,
      password: this.txtPassword
    };

    this.httpKlijent.post<LoginInformacije>("https://localhost:44308/Authentification/Login", saljemo)
      .subscribe((x: LoginInformacije) => {
        if (x != null) {
          AutentifikacijaHelper.setLoginInfo(x);
          alert("Welcome!");
          this.router.navigate([''])
            .then(() => {
              window.location.reload();
            });
        }
        else {
          AutentifikacijaHelper.setLoginInfo(null as any)
          alert("Login failed, please try again!");
        }
      });
  }

}
