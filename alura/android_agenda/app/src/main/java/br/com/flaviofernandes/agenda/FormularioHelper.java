package br.com.flaviofernandes.agenda;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RatingBar;

import br.com.flaviofernandes.agenda.modelo.Aluno;

public class FormularioHelper {
    private final ImageView foto;
    private final EditText nome;
    private final EditText endereco;
    private final EditText numero;
    private final EditText site;
    private final RatingBar nota;
    private Aluno aluno;

    public FormularioHelper(FormularioActivity activity) {
        nome = (EditText) activity.findViewById(R.id.formulario_nome);
        endereco = (EditText) activity.findViewById(R.id.formulario_endereco);
        numero = (EditText) activity.findViewById(R.id.formulario_numero);
        site = (EditText) activity.findViewById(R.id.formulario_site);
        nota = (RatingBar) activity.findViewById(R.id.formulario_nota);
        foto = (ImageView) activity.findViewById(R.id.formulario_foto);
        aluno = new Aluno();
    }

    public Aluno getAluno() {
        aluno.setNome(nome.getText().toString());
        aluno.setEndereco(endereco.getText().toString());
        aluno.setNumero(numero.getText().toString());
        aluno.setSite(site.getText().toString());
        aluno.setNota((double) nota.getProgress());
        aluno.setCaminhoFoto((String) foto.getTag());
        return aluno;
    }

    public void preencheFormulario(Aluno aluno) {
        nome.setText(aluno.getNome());
        endereco.setText(aluno.getEndereco());
        numero.setText(aluno.getNumero());
        site.setText(aluno.getSite());
        nota.setProgress(aluno.getNota().intValue());
        carregaImagem(aluno.getCaminhoFoto());
        this.aluno = aluno;
    }

    public void carregaImagem(String caminhoFoto) {
        if (caminhoFoto != null) {
            Bitmap bitmap = BitmapFactory.decodeFile(caminhoFoto);
            Bitmap bitmapReduzido = Bitmap.createScaledBitmap(bitmap, 300, 300, true);
            foto.setImageBitmap(bitmapReduzido);
            foto.setScaleType(ImageView.ScaleType.FIT_XY);
            foto.setTag(caminhoFoto);
        }
    }
}
