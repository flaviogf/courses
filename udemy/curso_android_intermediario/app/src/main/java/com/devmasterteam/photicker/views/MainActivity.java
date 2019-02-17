package com.devmasterteam.photicker.views;

import android.annotation.SuppressLint;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.MotionEvent;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;

import com.devmasterteam.photicker.R;
import com.devmasterteam.photicker.utils.ImageUtil;

public class MainActivity extends AppCompatActivity {

    private static class ViewHolder {
        LinearLayout painelCompartilhar;
        LinearLayout painelControle;
        ImageView imageViewZoomIn;
        ImageView imageViewZoomOut;
        ImageView imageViewEsquerda;
        ImageView imageViewDireita;
        ImageView imageViewFinalizar;
        ImageView imageViewExcluir;
        RelativeLayout relativeLayout;
        Runnable runnable;
        Boolean pressionando;
        Handler handler;
    }

    private ViewHolder mViewHolder = new ViewHolder();

    private ImageView mImagemSelecionada;

    @SuppressLint("ClickableViewAccessibility")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mViewHolder.handler = new Handler();

        getSupportActionBar().setDisplayShowTitleEnabled(false);
        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setIcon(R.mipmap.ic_launcher);

        LinearLayout mLinearLayout = findViewById(R.id.linear_layout_horizontal_scroll_view);
        mViewHolder.relativeLayout = findViewById(R.id.espaco_imagem_relativelayout);

        for (Integer idImagem : ImageUtil.listaIdBitmap()) {

            Bitmap bitmap = ImageUtil.decodeSampledBitmapFromResource(getResources(), idImagem, 70, 70);
            ImageView imagemParaEscolha = new ImageView(this);
            imagemParaEscolha.setPadding(10, 10, 10, 10);
            imagemParaEscolha.setImageBitmap(bitmap);
            mLinearLayout.addView(imagemParaEscolha);

            imagemParaEscolha.setOnClickListener(view -> {
                ImageView imagemAdicionada = new ImageView(this);
                imagemAdicionada.setImageBitmap(bitmap);
                mViewHolder.relativeLayout.addView(imagemAdicionada);

                RelativeLayout.LayoutParams layoutParams = (RelativeLayout.LayoutParams) imagemAdicionada.getLayoutParams();
                layoutParams.addRule(RelativeLayout.CENTER_HORIZONTAL);
                layoutParams.addRule(RelativeLayout.CENTER_VERTICAL);

                mImagemSelecionada = imagemAdicionada;


                imagemAdicionada.setOnTouchListener((view1, motionEvent) -> {
                    switch (motionEvent.getAction()) {
                        case MotionEvent.ACTION_DOWN:
                            mImagemSelecionada = (ImageView) view1;
                            exibePainelControle(true);
                            break;
                        case MotionEvent.ACTION_MOVE:
                            // pega a localização do realtive layout na tela pois o motion event retorna a posição do
                            // elemento clicado em relação a tela
                            int[] localizacao = {0, 0};
                            mViewHolder.relativeLayout.getLocationOnScreen(localizacao);
                            float rawY = motionEvent.getRawY();
                            float rawX = motionEvent.getRawX();
                            mImagemSelecionada.setY(rawY - ((localizacao[1] + 100) + (mImagemSelecionada.getHeight() / 2)));
                            mImagemSelecionada.setX(rawX - mImagemSelecionada.getWidth() / 2);
                            break;
                        case MotionEvent.ACTION_UP:
                            break;
                    }
                    return true;
                });

                exibePainelControle(true);
            });
        }

        mViewHolder.painelCompartilhar = findViewById(R.id.painel_compartilhar);
        mViewHolder.painelControle = findViewById(R.id.painel_controle);
        mViewHolder.imageViewZoomIn = findViewById(R.id.imageview_zoom_in);
        mViewHolder.imageViewZoomOut = findViewById(R.id.imageview_zoom_out);
        mViewHolder.imageViewEsquerda = findViewById(R.id.imageview_esquerda);
        mViewHolder.imageViewDireita = findViewById(R.id.imageview_direita);
        mViewHolder.imageViewFinalizar = findViewById(R.id.imageview_finalizar);
        mViewHolder.imageViewExcluir = findViewById(R.id.imageview_excluir);

        configuraListener();
    }

    @SuppressLint("ClickableViewAccessibility")
    private void configuraListener() {
        mViewHolder.imageViewZoomIn.setOnClickListener(view -> ImageUtil.zoomIn(mImagemSelecionada));
        mViewHolder.imageViewZoomOut.setOnClickListener(view -> ImageUtil.zoomOut(mImagemSelecionada));
        mViewHolder.imageViewEsquerda.setOnClickListener(view -> ImageUtil.rotacionaEsquerda(mImagemSelecionada));
        mViewHolder.imageViewDireita.setOnClickListener(view -> ImageUtil.rotacionaDireita(mImagemSelecionada));
        mViewHolder.imageViewFinalizar.setOnClickListener(view -> exibePainelControle(false));
        mViewHolder.imageViewExcluir.setOnClickListener(view -> mViewHolder.relativeLayout.removeView(mImagemSelecionada));

        mViewHolder.imageViewZoomIn.setOnTouchListener((this::atualizaEstadoPressionado));
        mViewHolder.imageViewZoomOut.setOnTouchListener((this::atualizaEstadoPressionado));

        mViewHolder.imageViewZoomIn.setOnLongClickListener(view -> {
            mViewHolder.runnable = () -> {
                if (mViewHolder.pressionando) {
                    ImageUtil.zoomIn(mImagemSelecionada);
                    mViewHolder.handler.postDelayed(mViewHolder.runnable, 50);
                }
            };
            mViewHolder.runnable.run();
            return false;
        });

        mViewHolder.imageViewZoomOut.setOnLongClickListener((view -> {
            mViewHolder.runnable = () -> {
                if (mViewHolder.pressionando) {
                    ImageUtil.zoomOut(mImagemSelecionada);
                    mViewHolder.handler.postDelayed(mViewHolder.runnable, 50);
                }
            };
            mViewHolder.runnable.run();
            return false;
        }));

        mViewHolder.imageViewEsquerda.setOnLongClickListener((view -> {
            mViewHolder.runnable = () -> {
                if (mViewHolder.pressionando) {
                    ImageUtil.rotacionaEsquerda(mImagemSelecionada);
                    mViewHolder.handler.postDelayed(mViewHolder.runnable, 50);
                }
            };
            mViewHolder.runnable.run();
            return false;
        }));

        mViewHolder.imageViewDireita.setOnLongClickListener((view -> {
            mViewHolder.runnable = () -> {
                if (mViewHolder.pressionando) {
                    ImageUtil.rotacionaDireita(mImagemSelecionada);
                    mViewHolder.handler.postDelayed(mViewHolder.runnable, 50);
                }
            };
            mViewHolder.runnable.run();
            return false;
        }));
    }

    private boolean atualizaEstadoPressionado(View view, MotionEvent motionEvent) {
        if (motionEvent.getAction() == MotionEvent.ACTION_DOWN) {
            mViewHolder.pressionando = true;
        }
        if (motionEvent.getAction() == MotionEvent.ACTION_UP) {
            mViewHolder.pressionando = false;
        }
        return false;
    }

    private void exibePainelControle(boolean status) {
        if (status) {
            mViewHolder.painelCompartilhar.setVisibility(View.GONE);
            mViewHolder.painelControle.setVisibility(View.VISIBLE);
        } else {
            mViewHolder.painelCompartilhar.setVisibility(View.VISIBLE);
            mViewHolder.painelControle.setVisibility(View.GONE);
        }
    }
}
