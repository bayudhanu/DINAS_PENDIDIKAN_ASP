import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { KelasService } from 'src/app/modules/services/kelas/kelas.service';
import { ErrorHandlerService } from 'src/app/modules/services/common/error-handler.service';
import { Table, TableLazyLoadEvent } from 'primeng/table';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Config } from 'datatables.net';
import { CustomerService } from 'src/app/modules/services/customer.service';
import { Customer, Representative } from 'src/app/modules/api/customer';
import { Kelas } from 'src/app/modules/api/kelas/kelas';
import { PageEvent } from 'src/app/modules/api/page-event';



interface expandedRows {
    [key: string]: boolean;
}

interface UploadEvent {
    originalEvent: Event;
    files: File[];
}

@Component({
    selector: 'app-kelas-list',
    providers: [MessageService, ConfirmationService],
    templateUrl: './kelas-list.component.html',
    styleUrl: './kelas-list.component.scss'
})

export class KelasListComponent implements OnInit {

    breadcrumbItems: MenuItem[] | undefined;

    home: MenuItem | undefined;

    kelas: Kelas = {};

    values: Kelas[] = [];

    selectedvalues: Customer[] = [];

    selectedCustomer: Customer = {};

    representatives: Representative[] = [];

    statuses: any[] = [];

    rowGroupMetadata: any;

    expandedRows: expandedRows = {};

    activityValues: number[] = [0, 100];

    isExpanded: boolean = false;

    idFrozen: boolean = false;

    loading: boolean = false;

    @ViewChild('filter') filter!: ElementRef;

    first: number = 0;
    rows: number = 10;
    columns = ['kode', 'nama', 'waliKelas'];
    dataTableOptions: Config = {};
    dataTableTrigger: Subject<any> = new Subject<any>();
    paginatedData: any[] = [];
    summaryData: any[] = [];
    event: PageEvent;

    totalPages: number = 0;
    currentPage: number = 0;
    totalRecords: number = 0;
    recordsPerPage: number = 10;

    dataLoaded: boolean;

    constructor(
        private customerService: CustomerService,
        private service: KelasService,
        private errorService: ErrorHandlerService
    ) {
        this.dataLoaded = false;
        this.loading = false;
    }

    ngOnInit() {
        this.breadcrumbItems = [
            { icon: 'pi pi-home', route: '/' },
            { label: 'Kesiswaan' },
            { label: 'Kesiswaan' },
            { label: 'Kelas' },
        ];

        this.loadData();

        this.customerService.getCustomersLarge().then(customers => {
            //this.values = customers;
            this.loading = true;

            // @ts-ignore
            this.values.forEach(customer => customer.date = new Date(customer.date));
            this.loading = false;
        });

        this.representatives = [
            { name: 'Amy Elsner', image: 'amyelsner.png' },
            { name: 'Anna Fali', image: 'annafali.png' },
            { name: 'Asiya Javayant', image: 'asiyajavayant.png' },
            { name: 'Bernardo Dominic', image: 'bernardodominic.png' },
            { name: 'Elwin Sharvill', image: 'elwinsharvill.png' },
            { name: 'Ioni Bowcher', image: 'ionibowcher.png' },
            { name: 'Ivan Magalhaes', image: 'ivanmagalhaes.png' },
            { name: 'Onyama Limba', image: 'onyamalimba.png' },
            { name: 'Stephen Shaw', image: 'stephenshaw.png' },
            { name: 'XuXue Feng', image: 'xuxuefeng.png' }
        ];

        this.statuses = [
            { label: 'Aktif', value: 'AKTIF' },
            { label: 'Tidak Aktif', value: 'TIDAK AKTIF' }
        ];
    }

    // Method to handle the update from the child component
    onItemChange(updatedItem: Kelas) {
        this.kelas = updatedItem;
    }

    onLazyLoad(event: any) {
        console.log("onLazyLoad => " + JSON.stringify(event));
        this.currentPage = event.first / event.rows;
        this.recordsPerPage = event.rows;
        this.loadData();
    }

    onDelete(kelas: Kelas) { }

    onSort() {
        this.updateRowGroupMetaData();
    }

    onGlobalFilter(table: Table, event: Event) {
        table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
    }

    updateRowGroupMetaData() {
        this.rowGroupMetadata = {};
    }

    expandAll() {
        if (!this.isExpanded) {
        } else {
            this.expandedRows = {};
        }
        this.isExpanded = !this.isExpanded;
    }

    formatCurrency(value: number) {
        return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    }

    clear(table: Table) {
        table.clear();
        this.filter.nativeElement.value = '';
    }

    loadData(): void {
        this.loading = true;
        this.service.getPaginatedData(this.currentPage, this.recordsPerPage).subscribe(
            (response) => {
                // Handle the retrieved data
                this.paginatedData = response?.data;
                this.values = this.paginatedData as Kelas[];
                this.summaryData = response?.summary;

                this.event = response?.meta;
                this.totalPages = this.event.totalPages;
                this.totalRecords = this.event.totalItems;
                this.currentPage = this.event.currentPage;
                this.recordsPerPage = this.event.itemsPerPage;

                this.dataLoaded = true;
                this.loading = false;

                console.log('Data fetched successfully'+ JSON.stringify(response));
            },
            (error) => {
                // Handle error
                this.errorService.handle(error);
                this.loading = false;
            }
        );
    }

    resetUsers(): void {
        this.paginatedData = [];
        this.dataLoaded = true;
        this.loading = false;
    }
}
