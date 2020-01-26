import { Injectable, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute } from "@angular/router";
import { Klachten } from "./klachten.model";

@Injectable({
  providedIn: "root"
})
export class KlachtenServiceService {
  public TotaalKlachten: Klachten[];

  readonly rootURL = "https://localhost:44310/";
  list: Klachten;

  constructor(private http: HttpClient) {}
}
