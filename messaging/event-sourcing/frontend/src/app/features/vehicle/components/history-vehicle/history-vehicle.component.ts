import { Component, OnInit } from '@angular/core';

import { BsModalRef } from 'ngx-bootstrap/modal';
import { StoredEvent } from 'src/app/shared/models/stored-event';

import { masks } from 'src/app/shared/utils/masks';
import { Vehicle } from '../../shared/models/vehicle';
import { VehicleService } from '../../shared/services/vehicle.service';

@Component({
    selector: 'app-history-vehicle',
    templateUrl: './history-vehicle.component.html',
    styleUrls: ['./history-vehicle.component.css']
})
export class HistoryVehicleComponent implements OnInit {
    public vehicle!: Vehicle;
    public plateMask: string = masks.plate;
    public storedEvents: StoredEvent[] = [];

    constructor(
        private bsModalRef: BsModalRef,
        private vehicleService: VehicleService
    ) { }

    public ngOnInit(): void {
        this.vehicleService.getHistory(this.vehicle.id).subscribe((storedEvents) => {
            this.storedEvents = storedEvents;
        });
    }

    public close(): void {
        this.bsModalRef.hide();
    }
}
