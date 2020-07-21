import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.css']
})
export class BreadcrumbComponent implements OnInit {

  @Input() CurrentPage: string = '';
  @Input() DependencyName: string = '';
  @Input() RouterName1: string = null;
  @Input() RouterName2: string = null;
  @Input() RouterName3: string = null;
  @Input() RouterName4: string = null;

  @Input() RouteTo1: string = '';
  @Input() RouteTo2: string = '';
  @Input() RouteTo3: string = '';
  @Input() RouteTo4: string = '';

  constructor() { }

  ngOnInit() {
  }

}
