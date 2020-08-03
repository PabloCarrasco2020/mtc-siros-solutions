import { Component, OnInit, ɵConsole } from '@angular/core';
import * as XLSX from 'xlsx';
import { IndexModel } from 'src/app/models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { CoordenadaRutaService, RutaService, MessageService, NotificationService } from 'src/app/services/services.index';
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

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;

  oIndexDataCoordenadas: IndexModel = new IndexModel();

  // BUSQUEDA
  nTipoFiltro: number = 1;
  sFilter: string = '';

  // FORMULARIO
  nIdRuta: number = 0;
  sNroRuta: string = '0';
  sNombreRuta: string = '';
  sItinerario: string = '';
  sKilometro: string = '';
  sEstado: string = '';

  // UPLOAD
  nIdRutaModal: number = 0; 
  file: File;
  filetext: string ='';
  arrayBuffer: any;
  //filelist: any;
  MAX_FILE_SIZE_MB = 1;
  MAX_EXCEL_ROWS = 5000;

  lstCoordenadas: any[] = [];
  lstDatos = [];

  EXCEL_COLUMNS_REGISTROS = [
    "number",
    "latitude",
    "longitude"
  ];

  @BlockUI() oBlockUI: NgBlockUI;
  constructor(
    private oRutaService: RutaService,
    private oCoordenadaRutaService: CoordenadaRutaService,
    private oMessageService: MessageService,
    private toastr : NotificationService) {

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

  //PAGINADO
  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRutas();
  }
  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRutas();
  }
  fnBeforeModal(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRutas();
    this.fnCoordenadas(this.nIdRutaModal);
  }
  fnNextModal(nPage: number){
    this.nCurrentPage = nPage;
    this.fnCoordenadas(this.nIdRutaModal);
  }
  //------------------------------------

  // CRUD
  fnRefresh(){
    this.CargarRutas();
  }
  fnRefreshModal(){
    this.fnCoordenadas(this.nIdRutaModal);
  }

  fnNew() {
    this.nCurrentOption = 1;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
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

  fnGuardar() {
    const warningDatos = this.ValidarDatos();
    if (warningDatos !== null) {
      this.oMessageService.warning(this.sTitlePage, warningDatos);
      return;
    }
    this.Guardar();
  }

  //------------------------------------

  //METODOS
  CargarRutas() {
    this.oBlockUI.start('Cargando Rutas...');
    console.log(this.sFilter);
    this.oRutaService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
      .then((response: ResponseModel<any>) => {

        if (response.IsSuccess) {
          this.toastr.success(`${response.Data.NroItems} Registros Encontrados`,this.sTitlePage);
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

  fnCoordenadas(id: number) {
    this.nIdRutaModal = id;
    this.oBlockUI.start('Cargando Coordenadas...');
    this.filetext = "";
    this.oCoordenadaRutaService.GetAllByFilter(this.nCurrentPage, `${id}`)
      .then((response: ResponseModel<any>) => {

        if (response.IsSuccess) {
          this.toastr.success(`${response.Data.NroItems} Registros Encontrados`,this.sTitlePage);
          this.oIndexDataCoordenadas = response.Data;
        } else {
          this.oIndexDataCoordenadas = new IndexModel();
        }
        this.oBlockUI.stop();
      });


    $('#myModalPoint').modal({backdrop: 'static', keyboard: false});
  }

  LimpiarCampos() {
    this.nIdRuta = 0;
    this.sNroRuta = '0';
    this.sNombreRuta = '';
    this.sItinerario = '';
    this.sKilometro = '';
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
    /*    
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
    */   
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
          Column3: item.longitude});
    });
  }

  fnUploadFile(){
    
    if (this.file == null) {
      this.oMessageService.error('Error al Cargar', 'Debe seleccionar un archivo valido para importar');
      return;
    }
    
    let filename = this.file.name;
    let regex = /^([a-zA-Z0-9 _-])+(.xls|.xlsx|.csv)$/;
    console.log(filename);
    if (!regex.test(filename)) {
      this.oMessageService.error('Error al Cargar', 'El nombre del archivo debe ser alfanumerico, de formato ".xls/.xlsx/.csv" Ejemplo: MI_ARCHIVO.xlsx');
        return;
    }

    let maxSize = this.MAX_FILE_SIZE_MB;
    let sizeBytes = Number(this.file.size);
    let sizeKb = (sizeBytes / 1024);
    let sizeMb = (sizeKb / 1024);
    console.log(sizeMb);
    if (sizeMb > maxSize) {
        this.oMessageService.error('Error al Cargar', `El tamaño del archivo no puede ser mayor a ${maxSize}MB.`);
        return;
    }

    this.oMessageService.confirm('¿Está seguro de cargar este archivo?',"Las coordenadas cargadas serán reemplazadas por los nuevos registros de este archivo")
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Procesando Archivo...');
        this.PreLoadExcel();
        this.oBlockUI.stop();
      }

    });

  }

  get_header_row(sheet) {
    var headers = [];
    var range = XLSX.utils.decode_range(sheet['!ref']);
    var C, R = range.s.r; 
    /* start in the first row * /
    /* walk every column in the range */
    for (C = range.s.c; C <= range.e.c; ++C) {
        var cell = sheet[XLSX.utils.encode_cell({ c: C, r: R })]

        /* find the cell in the first row */
        var hdr = "UNKNOWN " + C; // <-- replace with your desired default 
        if (cell && cell.t)
            hdr = XLSX.utils.format_cell(cell);

        headers.push(hdr);
    }
    return headers;
  }

  PreLoadExcel(){

    this.lstDatos = [];
  
    let fileReader = new FileReader();    
    fileReader.readAsArrayBuffer(this.file);     
    fileReader.onload = (e) => {    
        this.arrayBuffer = fileReader.result;    
        var data = new Uint8Array(this.arrayBuffer);    
        var arr = new Array();    
        for(var i = 0; i != data.length; ++i) arr[i] = String.fromCharCode(data[i]);    
        var bstr = arr.join("");   
        
        
        //LEER XLS FILE DATA
        //------------------------------------
        var workbook = XLSX.read(bstr, {type:"binary"});
        if (workbook.SheetNames == null) {
          this.oMessageService.error('Error al Cargar', `El archivo no tiene el formato correcto, debe usar la plantilla`,);
          return;
        }

        if (workbook.SheetNames.length != 1) {
          this.oMessageService.error('Error al Cargar', `El archivo no tiene el formato correcto, debe usar la plantilla`,);
          return;
        }
        //------------------------------------
        // VALIDAR FORMATO DE HOJA
        //------------------------------------
        var first_sheet_name = workbook.SheetNames[0];    
        var worksheet = workbook.Sheets[first_sheet_name];
        let excelColumnsREGISTROS = this.get_header_row(workbook.Sheets[first_sheet_name]);
        let columnsLengthREGISTROS = this.EXCEL_COLUMNS_REGISTROS.length;
        if (excelColumnsREGISTROS.length != columnsLengthREGISTROS) {
            this.oMessageService.error('Error al Cargar', `El numero de columnas del formato de carga no es valido. Debe tener ${columnsLengthREGISTROS} columnas.`);
            return;
        }

        let listColumnsInvalidREGISTROS = [];
        for (let i = 0; i < columnsLengthREGISTROS; i++) {
            if (excelColumnsREGISTROS[i] != this.EXCEL_COLUMNS_REGISTROS[i])
                listColumnsInvalidREGISTROS.push(excelColumnsREGISTROS[i]);
        }

        if (listColumnsInvalidREGISTROS.length > 0) {
            this.oMessageService.error('Error al Cargar',`El formato de carga no es el correcto. columnas invalidas: ${listColumnsInvalidREGISTROS}`);
            return;
        }
        //------------------------------------
        // VALIDAR NUMERO DE FILAS
        //------------------------------------
        var excelRows = XLSX.utils.sheet_to_json(worksheet,{raw:true});  
        let maxRowsCount = this.MAX_EXCEL_ROWS;
        if (excelRows.length > maxRowsCount) {
            this.oMessageService.error('Error al Cargar',`La cantidad de registros de carga no puede ser mayor de ${maxRowsCount} filas.`);
            return;
        }
        console.log(excelRows);
        //------------------------------------
        //this.lstCoordenadas = XLSX.utils.sheet_to_json(worksheet,{raw:true});  
        this.lstDatos = excelRows;
    } 
    

  }


}
