import { Injectable } from "@angular/core";
import { ManagerList } from "./manager.model";

@Injectable({
  providedIn: "root"
})
export class ManagerListService {
  formData: ManagerList;
  constructor() {}
}
