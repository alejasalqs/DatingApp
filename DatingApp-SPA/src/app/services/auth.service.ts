import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor(private http: HttpClient) {}
  baseUrl = "https://localhost:5001/Auth/";

  login(model: any) {
    return this.http.post(this.baseUrl + "login", model).pipe(
      // descompone el cuerpo y guarda el token en el localstorage
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem("token", user.token);
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + "register", model);
  }
}
