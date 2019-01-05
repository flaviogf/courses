import { PhotosModule } from './photos.module';

describe('PhotosModule', () => {
  let photosModule: PhotosModule;

  beforeEach(() => {
    photosModule = new PhotosModule();
  });

  it('should create an instance', () => {
    expect(photosModule).toBeTruthy();
  });
});
