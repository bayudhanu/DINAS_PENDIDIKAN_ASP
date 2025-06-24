import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
// import { SiswaService } from 'src/app/modules/services/kelas/kelas.service';
import { ErrorHandlerService } from 'src/app/modules/services/common/error-handler.service';
import { Table } from 'primeng/table';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Config } from 'datatables.net';
import { CustomerService } from 'src/app/modules/services/customer.service';
import { Customer, Representative } from 'src/app/modules/api/customer';
import { Product } from 'src/app/modules/api/product';
import { ProductService } from 'src/app/modules/services/product.service';
import { FileUploadModule } from 'primeng/fileupload';
import { ToastModule } from 'primeng/toast';
import { Siswa } from 'src/app/modules/api/siswa/siswa';

interface PageEvent {
    first: number;
    rows: number;
    page: number;
    pageCount: number;
}

interface expandedRows {
    [key: string]: boolean;
}

interface UploadEvent {
    originalEvent: Event;
    files: File[];
}

@Component({
    selector: 'app-siswa-list',
    templateUrl: './siswa-list.component.html',
    styleUrl: './siswa-list.component.scss',
    providers: [MessageService, ConfirmationService],
})

export class SiswaListComponent implements OnInit {
    breadcrumbItems: MenuItem[] | undefined;

    dropdownOptionButton: MenuItem[];

    visible = false

    // siswa: Siswa = {};

    values: Siswa[] = [];

    representatives: Representative[] = [];

    statuses: any[];

    rowGroupMetadata: any;

    expandedRows: expandedRows = {};

    isExpanded: boolean = false;

    loading: boolean = false;

    @ViewChild('filter') filter!: ElementRef;

    first: number = 0;
    rows: number = 10;
    columns = ['kode', 'nama', 'waliKelas'];
    dataTableOptions: Config = {};
    dataTableTrigger: Subject<any> = new Subject<any>();
    paginatedData: any[] = [];
    summaryData: any[] = [];
    currentPage: number = 1;
    itemsPerPage: number = 10;
    totalPages: number = 1;
    totalItems!: number;
    loaded: boolean;

    constructor(
        private customerService: CustomerService, 
        // private service: SiswaService,
        private errorService: ErrorHandlerService,
        private messageService: MessageService
    ) {
        this.loaded = false;
      }

    ngOnInit() {
        this.breadcrumbItems = [
            { icon: 'pi pi-home', route: '/' },
            { label: 'Kesiswaan' },
            { label: 'Kesiswaan' },
            { label: 'Siswa' }
        ];
        
        this.dropdownOptionButton = [
            { 
                label: 'Upload Data Siswa',
                command: () => {
                    this.dialogUploadSiswa();
                }
            },
            {
                label: 'Download Data Siswa',
                command: () => {
                }
            },
        ];
    }

    clear(table: Table) {
        table.clear();
        this.filter.nativeElement.value = '';
    }

    onGlobalFilter(table: Table, event: Event) {
        table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
    }
   
    dialogUploadSiswa() {
        this.visible = true
    }
}
