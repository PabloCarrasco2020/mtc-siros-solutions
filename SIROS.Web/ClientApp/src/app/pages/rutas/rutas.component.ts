import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import { IndexModel } from 'src/app/models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { RutaService, ComboService, MessageService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { timeStamp } from 'console';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

declare var $: any;
@Component({
  selector: 'app-rutas',
  templateUrl: './rutas.component.html',
  styleUrls: ['./rutas.component.css']
})
export class RutasComponent implements OnInit {
  sTitlePage: string = 'Ruta';
  file: File;
  arrayBuffer: any;
  filelist: any;

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;

  oIndexDataCoordenadas: IndexModel = new IndexModel();

  public lstCoordenadas: any[] = [];

  // Busqueda
  nTipoFiltro: number = 1;
  sFilter: string = '';

  // FORMULARIO
  nIdRuta: number = 0;
  sNroRuta: string = '0';
  sNombreRuta: string = '';
  sItinerario: string = '';
  sKilometro: string = '';
  sEstado: string = '';

  @BlockUI() oBlockUI: NgBlockUI;
  constructor(
    private oRutaService: RutaService,
    private oMessageService: MessageService) {

    this.CargarRutas();
  }

  ngOnInit() {
    $(document).prop('title', 'SIROS - Ruta');
  }

  fnChangeTipoBusqueda(nOption: number) {
    this.nTipoFiltro = nOption;
    this.sFilter = '';
    setTimeout(() => {
      document.getElementById(`sFilter${nOption}`).focus();
    }, 0);
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarRutas();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRutas();
  }

  fnRefresh(){
    this.CargarRutas();
  }
  
  fnExport(){
    
  }

  fnNew() {
    this.nCurrentOption = 1;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }

  fnCoordenadas(id: number) {
    console.log(id);
    $('#myModalPoint').modal({backdrop: 'static', keyboard: false});
  }

  fnEdit(nId: number) {
    this.nCurrentOption = 2;
    this.LimpiarCampos();
    this.nIdRuta = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarRutaXId();
  }

  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar la ruta?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando Ruta.');
        
        this.oRutaService.Delete(nId).then((response: ResponseModel<any>) => {
            if (response.IsSuccess) {
              this.oMessageService.success(this.sTitlePage, response.Message);
              this.oBlockUI.stop();
              this.CargarRutas();
            } else {
              if (response.Message.startsWith('ERR-')) {
                this.oMessageService.error(this.sTitlePage, response.Message);
              } else {
                this.oMessageService.warning(this.sTitlePage, response.Message);
              }
              this.oBlockUI.stop();
            }
          });
        
      }
    });
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRutas();
  }

  CargarRutas() {
    this.oBlockUI.start('Cargando Rutas...');
    console.log(this.sFilter);
    this.oRutaService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
      .then((response: ResponseModel<any>) => {

        if (response.IsSuccess) {
          this.oIndexData = response.Data;
        } else {
          this.oIndexData = new IndexModel();
        }
        this.oBlockUI.stop();
      });
  }

  CargarRutaXId() {
    this.oBlockUI.start('Cargando Ruta...');
    this.oRutaService.Get(this.nIdRuta).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        console.log(response.Data)
        this.nIdRuta = response.Data.nIdRuta;
        this.sNroRuta = response.Data.sNroRuta;
        this.sNombreRuta = response.Data.sNombreRuta;
        this.sItinerario = response.Data.sItinerario === null ? '' : response.Data.sItinerario;
        this.sKilometro = response.Data.sKilometro === null ? '' : response.Data.sKilometro;
        this.sEstado = response.Data.sEstado === null ? '' : response.Data.sEstado;
      } else {

      }
      this.oBlockUI.stop();
    });
    
  }

  LimpiarCampos() {
    this.nIdRuta = 0;
    this.sNroRuta = '0';
    this.sNombreRuta = '';
    this.sItinerario = '';
    this.sKilometro = '';
  }

  fnGuardar() {
    const warningDatos = this.ValidarDatos();
    if (warningDatos !== null) {
      this.oMessageService.warning(this.sTitlePage, warningDatos);
      return;
    }
    this.Guardar();
  }

  Guardar() {
    this.oBlockUI.start('Guardando Ruta..');
    this.sEstado = '1';
    if (this.nCurrentOption === 1) {

      this.oRutaService.Insert(
        this.sNombreRuta,
        this.sItinerario,
        this.sKilometro,
        this.sEstado
      ).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarRutas();
        } else {
          if (response.Message.startsWith('ERR-')) {
            this.oMessageService.error(this.sTitlePage, response.Message);
          } else {
            this.oMessageService.warning(this.sTitlePage, response.Message);
          }
          this.oBlockUI.stop();
        }
      });
      
    } else if (this.nCurrentOption === 2) {

      this.oRutaService.Update(
        this.nIdRuta,
        this.sNroRuta,
        this.sNombreRuta,
        this.sItinerario,
        this.sKilometro,
        this.sEstado
      ).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarRutas();
        } else {
          if (response.Message.startsWith('ERR-')) {
            this.oMessageService.error(this.sTitlePage, response.Message);
          } else {
            this.oMessageService.warning(this.sTitlePage, response.Message);
          }
          this.oBlockUI.stop();
        }
      });
      //

    }
  }
  ValidarDatos(): any {
    if (
        (this.sNombreRuta.length === 0 ) ||
        (this.sItinerario.length === 0) ||
        (this.sKilometro.length === 0) 
      ){
      return  ' Completar los campos con (*),  son obligatorios';
    }
    return null;
  }

  fnReadFile(event){
    this.file= event.target.files[0];     
    let fileReader = new FileReader();    
    fileReader.readAsArrayBuffer(this.file);     
    fileReader.onload = (e) => {    
        this.arrayBuffer = fileReader.result;    
        var data = new Uint8Array(this.arrayBuffer);    
        var arr = new Array();    
        for(var i = 0; i != data.length; ++i) arr[i] = String.fromCharCode(data[i]);    
        var bstr = arr.join("");    
        var workbook = XLSX.read(bstr, {type:"binary"});    
        var first_sheet_name = workbook.SheetNames[0];    
        var worksheet = workbook.Sheets[first_sheet_name];    
        console.log(XLSX.utils.sheet_to_json(worksheet,{raw:true}));    
          this.lstCoordenadas = XLSX.utils.sheet_to_json(worksheet,{raw:true});     
              //this.filelist = [];    
              //console.log(this.filelist)
              
    }    
  } 

  fnLoadCoordenadas(){
    this.ParseListToIndexCoordenadas();
  }

  ParseListToIndexCoordenadas() {
    this.oIndexDataCoordenadas = new IndexModel();
    this.oIndexDataCoordenadas.NroItems = this.lstCoordenadas.length;
    this.oIndexDataCoordenadas.TotalPage = 1;
    this.oIndexDataCoordenadas.ActualPage = 1;
    this.oIndexDataCoordenadas.Items = [];
    let iCoordenada = 0;
    this.lstCoordenadas.forEach(item => {
      iCoordenada++;
      this.oIndexDataCoordenadas.Items.push(
        {
          Id: iCoordenada,
          Column1: item.number,
          Column2: item.latitude,
         // Column3: `${item.sNombres} ${responsableLegal.sApePaterno} ${responsableLegal.sApeMaterno}`,
          Column3: item.longitude});
    });
  }

}
