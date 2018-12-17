//dependencias
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

//modulo principal
import AppModule from './app.module';

const platform = platformBrowserDynamic();

platform.bootstrapModule(AppModule);
