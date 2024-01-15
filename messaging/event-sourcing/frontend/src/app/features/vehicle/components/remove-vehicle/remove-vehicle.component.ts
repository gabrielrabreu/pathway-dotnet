import { Component, OnInit } from '@angular/core';

import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';

import { masks } from 'src/app/shared/utils/masks';
import { Vehicle } from '../../shared/models/vehicle';
import { VehicleService } from '../../shared/services/vehicle.service';

@Component({
    selector: 'app-remove-vehicle',
    templateUrl: './remove-vehicle.component.html'
})
export class RemoveVehicleComponent implements OnInit {
    public vehicle!: Vehicle;
    public errors: string[] = [];
    public submitting: boolean = false;
    public plateMask: string = masks.plate;
    public onClose!: Subject<boolean>;

    constructor(
        private vehicleService: VehicleService,
        private bsModalRef: BsModalRef,
        private toastrService: ToastrService
    ) { }

    public ngOnInit(): void {
        this.onClose = new Subject();
    }

    public confirm(): void {
        this.submitting = true;
        this.vehicleService.remove(this.vehicle.id).subscribe(
            () => {
                this.toastrService.success('Vehicle successfully removed.');
                this.onClose.next(true);
                this.close();
            },
            failure => {
                this.errors = failure.errors;
                this.submitting = false;
            }
        )
    }

    public close(): void {
        this.bsModalRef.hide();
    }
}
