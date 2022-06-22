import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';
@Component({
  selector: 'app-registration-page',
  templateUrl: './registration-page.component.html',
  styleUrls: ['./registration-page.component.css']
})
export class RegistrationPageComponent implements OnInit {
  txtUsername: any;
  txtPassword: any;
  txtName: any;
  txtLastname: any;
  txtEmail: any;
  txtDate: any;
  txtCity: any;
  txtGender: any;

  Genders: any;
  Cities: any;
  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.LoadCities();
    this.LoadGenders();
  }
  LoadCities() {
    this.httpKlijent.get("https://localhost:44308/City/GetAll")
      .subscribe((x: any) => {
        this.Cities = x;

      })
  }

  LoadGenders() {
    this.httpKlijent.get("https://localhost:44308/Gender/GetAll").subscribe((x: any) => {
      this.Genders = x;
    })
  }

  Registration() {

    let saljemo = {
      name: this.txtName,
      lastname: this.txtLastname,
      email: this.txtEmail,
      birthdate: this.txtDate,
      username: this.txtUsername,
      password: this.txtPassword,
      city_id: this.txtCity,
      gender_id: this.txtGender
    };

    this.httpKlijent.post("https://localhost:44308/User/Add", saljemo)
      .subscribe((x: any) => {
        if (x != null) {
          alert("Registration successfull!");
          this.router.navigateByUrl("/login");
        }
        else {
          alert("Registration failed or username already exists!");
        }
      });

  }
}
