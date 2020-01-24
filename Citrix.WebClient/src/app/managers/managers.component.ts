import { Component, OnInit } from "@angular/core";
import { ManagerListService } from "../shared/Manager/manager-list.service";

@Component({
  selector: "app-managers",
  templateUrl: "./managers.component.html",
  styles: []
})
export class ManagersComponent implements OnInit {
  constructor(private service: ManagerListService) {}

  ngOnInit() {}
}
