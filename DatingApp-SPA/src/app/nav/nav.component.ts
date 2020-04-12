import { Component, OnInit } from "@angular/core";
import { AuthService } from "../services/auth.service";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"],
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      (next) => {
        console.log("Loggin Succsefull");
      },
      (error) => {
        console.log(error);
      }
    );
  }

  loggedIn() {
    const token = localStorage.getItem("token");
    // si encuentra algo retorna true y si esta vacio retorna false
    return !!token;
  }

  logOut() {
    localStorage.removeItem("token");
    console.log("log out");
  }
}
