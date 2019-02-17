package com.devmasterteam.photicker.utils;

import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.devmasterteam.photicker.R;

import java.util.ArrayList;
import java.util.List;

public class ImageUtil {

    public static List<Integer> listaIdBitmap() {
        List<Integer> bitmaps = new ArrayList<>();
        bitmaps.add(R.drawable.st_animal_0);
        bitmaps.add(R.drawable.st_animal_2);
        bitmaps.add(R.drawable.st_animal_3);
        bitmaps.add(R.drawable.st_animal_4);
        bitmaps.add(R.drawable.st_animal_5);
        bitmaps.add(R.drawable.st_animal_6);
        bitmaps.add(R.drawable.st_animal_7);
        bitmaps.add(R.drawable.st_animal_8);
        bitmaps.add(R.drawable.st_animal_10);
        bitmaps.add(R.drawable.st_animal_11);
        bitmaps.add(R.drawable.st_animal_12);
        bitmaps.add(R.drawable.st_animal_13);
        bitmaps.add(R.drawable.st_animal_14);
        bitmaps.add(R.drawable.st_animal_16);
        bitmaps.add(R.drawable.st_animal_17);
        bitmaps.add(R.drawable.st_animal_18);
        bitmaps.add(R.drawable.st_animal_19);
        bitmaps.add(R.drawable.st_animal_20);
        bitmaps.add(R.drawable.st_animal_21);
        bitmaps.add(R.drawable.st_animal_22);
        bitmaps.add(R.drawable.st_animal_23);
        bitmaps.add(R.drawable.st_animal_24);
        bitmaps.add(R.drawable.st_animal_25);
        bitmaps.add(R.drawable.st_animal_26);
        bitmaps.add(R.drawable.st_animal_27);
        bitmaps.add(R.drawable.st_animal_28);
        bitmaps.add(R.drawable.st_animal_29);
        return bitmaps;
    }

    public static int calculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight) {
        final int height = options.outHeight;
        final int width = options.outWidth;
        int inSampleSize = 1;
        if (height > reqHeight || width > reqWidth) {
            final int halfHeight = height / 2;
            final int halfWidth = width / 2;
            while ((halfHeight / inSampleSize) >= reqHeight
                    && (halfWidth / inSampleSize) >= reqWidth) {
                inSampleSize *= 2;
            }
        }
        return inSampleSize;
    }

    public static Bitmap decodeSampledBitmapFromResource(Resources res, int resId, int reqWidth, int reqHeight) {
        final BitmapFactory.Options options = new BitmapFactory.Options();
        options.inJustDecodeBounds = true;
        BitmapFactory.decodeResource(res, resId, options);
        options.inSampleSize = calculateInSampleSize(options, reqWidth, reqHeight);
        options.inJustDecodeBounds = false;
        return BitmapFactory.decodeResource(res, resId, options);
    }

    public static void zoomIn(ImageView imagemSelecionada) {
        ViewGroup.LayoutParams layoutParams = imagemSelecionada.getLayoutParams();
        layoutParams.width = (int) (imagemSelecionada.getWidth() + imagemSelecionada.getWidth() * .1);
        layoutParams.height = (int) (imagemSelecionada.getHeight() + imagemSelecionada.getHeight() * .1);
        imagemSelecionada.setLayoutParams(layoutParams);
    }

    public static void zoomOut(ImageView imagemSelecionada) {
        ViewGroup.LayoutParams layoutParams = imagemSelecionada.getLayoutParams();
        layoutParams.width = (int) (imagemSelecionada.getWidth() - imagemSelecionada.getWidth() * .1);
        layoutParams.height = (int) (imagemSelecionada.getHeight() - imagemSelecionada.getHeight() * .1);
        imagemSelecionada.setLayoutParams(layoutParams);
    }

    public static void rotacionaEsquerda(ImageView imagemSelecionada) {
        imagemSelecionada.setRotation(imagemSelecionada.getRotation() - 5);
    }

    public static void rotacionaDireita(ImageView imagemSelecionada) {
        imagemSelecionada.setRotation(imagemSelecionada.getRotation() + 5);
    }

    public static void finaliza(ImageView imagemSelecionada) {

    }
}
