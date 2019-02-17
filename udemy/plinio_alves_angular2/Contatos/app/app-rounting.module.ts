//dependencias
import { NgModule } from '@angular/core';
import { RouterModule, Route } from '@angular/router';

const appRoutes: Route[] = [
    {
        path: '',
        redirectTo: '/contato',
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [ RouterModule.forRoot(appRoutes) ],
    exports: [ RouterModule ]
})
export default class AppRoutingModule {}
