import { Attribute, Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Kelas } from 'src/app/modules/api/kelas/kelas';

@Component({
    selector: 'app-edit-kelas',
    templateUrl: './edit-kelas.component.html',
    styleUrl: './edit-kelas.component.scss'
})
export class EditKelasComponent implements OnInit, OnDestroy {

    visible: boolean = false;
    submitted: boolean = false;

    dropdownUnitSekolah: any[];
    selectedUnitSekolah: any;

    dropdownWaliKelas: any[];
    selectedWaliKelas: any;

    items: Kelas[] = [];
    @Input() item: Kelas = {};
    @Output() itemChange = new EventEmitter<Kelas>();

    constructor(
        private messageService: MessageService
    ) { }

    ngOnInit(): void {
        this.dropdownUnitSekolah = [
            { name: 'TK', code: '1' },
            { name: 'SD', code: '2' },
            { name: 'SMP', code: '3' },
            { name: 'SMA', code: '4' },
            { name: 'SMK', code: '5' },
        ];

        this.dropdownWaliKelas = [
            { name: 'Wali 1', code: '1' },
            { name: 'Wali 2', code: '2' },
            { name: 'Wali 3', code: '3' },
            { name: 'Wali 4', code: '4' },
            { name: 'Wali 5', code: '5' },
            { name: 'Wali 6', code: '6' },
            { name: 'Wali 7', code: '7' },
            { name: 'Wali 8', code: '8' },
            { name: 'Wali 9', code: '9' },
            { name: 'Wali 10', code: '10' },
            { name: 'Wali 11', code: '11' },
        ];
     }

    ngOnDestroy(): void {
        this.item = {};
    }

    onEdit() {
        this.itemChange.emit(this.item);
        this.visible = true;

        const selectedUnitSekolahName = this.item.unitSekolah?.toLowerCase();
        const selectedUnitSekolahIndex = this.dropdownUnitSekolah.findIndex((x: { name: string; code: string }) => x.name.toLowerCase() === selectedUnitSekolahName);
        this.selectedUnitSekolah = this.dropdownUnitSekolah[selectedUnitSekolahIndex];


        const selectedWaliKelasName: string = this.item.namaWaliKelas?.toLowerCase();
        const selectedWaliKelasIndex: number = this.dropdownWaliKelas.findIndex((x: { name: string; code: string }) => x.name.toLowerCase() === selectedWaliKelasName);
        this.selectedWaliKelas = this.dropdownWaliKelas[selectedWaliKelasIndex];
    }

    onClose() {
        this.visible = false;
        this.submitted = false;
    }

    findIndexById(id: number): number {
        let index = -1;
        for (let i = 0; i < this.items.length; i++) {
            if (this.items[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    }

    save() {
        this.submitted = true;

        if (this.item.nama?.trim()) {
            if (this.item.id) {
                // @ts-ignore
                this.items[this.findIndexById(this.item.id)] = this.item;
                this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'item Updated', life: 3000 });
            } else {
                this.item.kode = this.createId();
                this.item.nama = 'item-placeholder.svg';
                // @ts-ignore
                this.items.push(this.item);
                this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'item Created', life: 3000 });
            }

            this.items = [...this.items];
            this.visible     = false;
            this.item = {};
        }
    }


    createId(): string {
        let id = '';
        const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        for (let i = 0; i < 5; i++) {
            id += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        return id;
    }

}
