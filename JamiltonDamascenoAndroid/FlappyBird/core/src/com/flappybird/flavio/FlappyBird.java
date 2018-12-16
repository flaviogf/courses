package com.flappybird.flavio;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Circle;
import com.badlogic.gdx.math.Intersector;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.utils.viewport.StretchViewport;

import java.util.Random;

public class FlappyBird extends ApplicationAdapter {
    private SpriteBatch batch;
    private Texture[] passaros = new Texture[3];
    private Texture fundo;
    private Texture canoTopo;
    private Texture canoBaixo;
    private Texture gameOver;
    private BitmapFont fonte;
    //private ShapeRenderer shape;

    private float height;
    private float width;
    private float deltaTime;

    private float altura;
    private float variacao;
    private float velocidadeQueda;
    private float posicaoCanoHorizontal;
    private float posicaoCanoVertical;
    private int espacoCanos = 300;
    private Random random = new Random();
    private int statusJogo = 0;
    private int pontuacao = 0;
    private boolean controlePontucao = false;
    private Circle circuloPassaro;
    private Rectangle retanguloCanoTopo;
    private Rectangle retanguloCanoBaixo;

    private OrthographicCamera camera;
    private StretchViewport viewport;

    private static final int VIRTUAL_WIDTH = 768;
    private static final int VIRTUAL_HEIGT = 1024;

    @Override
    public void create() {
        camera = new OrthographicCamera();
        viewport = new StretchViewport(VIRTUAL_WIDTH, VIRTUAL_HEIGT, camera);

        camera.position.set(VIRTUAL_WIDTH / 2, VIRTUAL_HEIGT / 2, 0);

        batch = new SpriteBatch();
        fonte = new BitmapFont();
        //shape = new ShapeRenderer();
        circuloPassaro = new Circle();
        retanguloCanoTopo = new Rectangle();
        retanguloCanoBaixo = new Rectangle();
        fonte.setColor(Color.WHITE);
        fonte.getData().setScale(6);

        fundo = new Texture("fundo.png");
        passaros[0] = new Texture("passaro1.png");
        passaros[1] = new Texture("passaro2.png");
        passaros[2] = new Texture("passaro3.png");
        canoTopo = new Texture("cano_topo.png");
        canoBaixo = new Texture("cano_baixo.png");
        gameOver = new Texture("game_over.png");

        height = VIRTUAL_HEIGT;
        width = VIRTUAL_WIDTH;

        altura = height / 2;
        posicaoCanoHorizontal = width;
    }

    @Override
    public void render() {

        camera.update();

        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        deltaTime = Gdx.graphics.getDeltaTime();
        variacao += deltaTime * 10;

        if (variacao > 2) variacao = 0;

        if (statusJogo == 0) {
            if (Gdx.input.justTouched()) {
                statusJogo = 1;
            }
        } else {
            velocidadeQueda++;
            if (altura > 0 || velocidadeQueda < 0) {
                altura -= velocidadeQueda;
            } else {
                altura = 0;
            }

            if (statusJogo == 1) {
                posicaoCanoHorizontal -= deltaTime * 200;

                if (Gdx.input.justTouched()) {
                    velocidadeQueda = -15;
                }

                if (posicaoCanoHorizontal <= -canoBaixo.getWidth()) {
                    posicaoCanoVertical = random.nextInt(400) - 200;
                    posicaoCanoHorizontal = width;
                    controlePontucao = false;
                }

                if (posicaoCanoHorizontal <= 120) {
                    if (!controlePontucao) {
                        pontuacao++;
                        controlePontucao = true;
                    }
                }
            } else {
                if (Gdx.input.justTouched()) {
                    statusJogo = 0;
                    pontuacao = 0;
                    altura = height / 2;
                    posicaoCanoHorizontal = width;
                    velocidadeQueda = 0;
                    variacao = 0;
                }
            }
        }

        batch.setProjectionMatrix(camera.combined);

        batch.begin();

        batch.draw(fundo, 0, 0, width, height);
        batch.draw(canoTopo, posicaoCanoHorizontal, (height / 2) + posicaoCanoVertical + espacoCanos / 2);
        batch.draw(canoBaixo, posicaoCanoHorizontal, (height / 2 - canoTopo.getHeight()) + posicaoCanoVertical - espacoCanos / 2);
        batch.draw(passaros[(int) variacao], 120, altura);
        fonte.draw(batch, String.valueOf(pontuacao), width / 2, height - 50);

        if (statusJogo == 2) {
            batch.draw(gameOver, width / 2 - gameOver.getWidth() / 2, height / 2);
        }

        batch.end();

        circuloPassaro.set(120 + passaros[0].getWidth() / 2, altura + passaros[0].getHeight() / 2, passaros[0].getWidth() / 2);

        retanguloCanoBaixo.set(
                posicaoCanoHorizontal, (height / 2 - canoTopo.getHeight()) + posicaoCanoVertical - espacoCanos / 2,
                canoBaixo.getWidth(), canoBaixo.getHeight()
        );

        retanguloCanoTopo.set(
                posicaoCanoHorizontal, (height / 2) + posicaoCanoVertical + espacoCanos / 2,
                canoTopo.getWidth(), canoTopo.getHeight()
        );

        if (Intersector.overlaps(circuloPassaro, retanguloCanoBaixo) || Intersector.overlaps(circuloPassaro, retanguloCanoTopo) || altura >= height || altura <= 0) {
            statusJogo = 2;
        }

        /*
        shape.begin(ShapeRenderer.ShapeType.Filled);
        shape.setColor(Color.RED);
        shape.circle(circuloPassaro.x, circuloPassaro.y, circuloPassaro.radius);
        shape.rect(retanguloCanoBaixo.x, retanguloCanoBaixo.y, retanguloCanoBaixo.width, retanguloCanoBaixo.height);
        shape.rect(retanguloCanoTopo.x, retanguloCanoTopo.y, retanguloCanoTopo.width, retanguloCanoTopo.height);
        shape.end();
        */
    }

    @Override
    public void resize(int width, int height) {
        viewport.update(width, height);
    }
}