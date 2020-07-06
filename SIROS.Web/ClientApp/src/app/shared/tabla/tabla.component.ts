import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IndexModel } from '../../models/IndexModel';

@Component({
  selector: 'app-tabla',
  templateUrl: './tabla.component.html',
  styles: []
})
export class TablaComponent implements OnInit {

  @Input() Column1Name: string = null;
  @Input() Column2Name: string = null;
  @Input() Column3Name: string = null;
  @Input() Column4Name: string = null;
  @Input() Column5Name: string = null;
  @Input() Column6Name: string = null;
  @Input() Column7Name: string = null;
  @Input() Column8Name: string = null;
  @Input() Column9Name: string = null;
  @Input() Column10Name: string = null;

  @Input() IndexData: IndexModel =  new IndexModel();

  @Input() CanNew: boolean = false;
  @Input() CanEdit: boolean = false;
  @Input() CanView: boolean = false;
  @Input() CanDelete: boolean = false;
  @Input() CanSelect: boolean = false;
  @Input() CanSearch: boolean = false;

  @Output() eventNew = new EventEmitter<null>();
  @Output() eventRegistrar = new EventEmitter<null>();
  @Output() eventEdit = new EventEmitter<number>();
  @Output() eventDelete = new EventEmitter<number>();
  @Output() eventView = new EventEmitter<number>();
  @Output() eventSelect = new EventEmitter<number>();
  @Output() eventSearch = new EventEmitter<string>();

  @Output() eventNext = new EventEmitter<number>();
  @Output() eventBefore = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  btnRegistrar() {
    this.eventRegistrar.emit(null);
  }

  btnNew() {
    this.eventNew.emit(null);
  }

  btnEdit(id: number) {
    this.eventEdit.emit(id);
  }

  btnDelete(id: number) {
    this.eventDelete.emit(id);
  }

  chkSelect(id: number) {
    this.eventSelect.emit(id);
  }

  btnView(id: number) {
    this.eventView.emit(id);
  }

  btnNext() {
    this.eventNext.emit(this.IndexData.ActualPage + 1);
  }

  btnBefore() {
    this.eventBefore.emit(this.IndexData.ActualPage - 1);
  }

  btnSearch(sFilter: string) {
    this.eventSearch.emit(sFilter);
  }
}
