import { Component } from '@angular/core';
import { AutentifikacijaHelper } from './_helpers/autentifikacija-helper';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SRFrontend';

  isLog: boolean = AutentifikacijaHelper.getLoginInfo().isLogiran;
  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  logout() {
    if (this.isLog == true) {
      this.httpKlijent.post("https://localhost:44308/Authentification/Logout", "")
        .subscribe((x: any) => {

        })
      AutentifikacijaHelper.setLoginInfo(null as any);
      this.router.navigate([''])
        .then(() => {
          window.location.reload();
        });
    }
    else {

      this.router.navigateByUrl("/login");

    }
  }
}
