package br.com.flaviogf;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

import javax.swing.*;

public class LoginApp extends Application {

    private VBox root;
    private TextField loginField;
    private PasswordField senhaField;
    private Button entrarButton;
    private Button sairButton;

    private static Stage stage;

    @Override
    public void start(Stage stage) {
        inicializaComponentes();
        inicializaListerners();
        inicializaLayout();

        var cena = new Scene(root);

        stage.setTitle("Login GolFX");
        stage.setResizable(false);
        stage.setScene(cena);
        stage.sizeToScene();
        stage.show();

        LoginApp.stage = stage;
    }

    private void inicializaComponentes() {
        loginField = new TextField();
        loginField.setPromptText("Login");

        senhaField = new PasswordField();
        senhaField.setPromptText("Senha");

        entrarButton = new Button("Entrar");
        sairButton = new Button("Sair");

        root = new VBox();
    }

    private void inicializaListerners() {
        entrarButton.setOnAction(this::autentica);
        sairButton.setOnAction(this::fechaApp);
    }

    private void inicializaLayout() {
        var campos = new VBox();
        campos.setPadding(new Insets(10));
        campos.setSpacing(10);
        campos.getChildren().addAll(loginField, senhaField);

        var botoes = new HBox();
        botoes.setPadding(new Insets(10));
        botoes.setSpacing(10);
        botoes.setAlignment(Pos.CENTER_RIGHT);
        botoes.getChildren().addAll(entrarButton, sairButton);

        root.setPrefSize(400, 300);
        root.getChildren().addAll(campos, botoes);
    }

    private void autentica(ActionEvent event) {
        String login = loginField.getText();
        String senha = senhaField.getText();
        if (login.equals("admin") && senha.equals("teste123")) {
            new VitrineApp().start(new Stage());
            LoginApp.stage.close();
        } else {
            JOptionPane.showMessageDialog(null, "Login ou senha inválidos");
        }
    }

    private void fechaApp(ActionEvent event) {
        LoginApp.stage.close();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
