package br.com.flaviogf.technews.activities;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;

import com.google.android.material.textfield.TextInputLayout;

import java.util.UUID;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.infrastructure.Maybe;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.service.MemoryNewsService;
import br.com.flaviogf.technews.service.NewsService;
import br.com.flaviogf.technews.viewmodels.TechViewModel;
import br.com.flaviogf.technews.viewmodels.TechViewModelFactory;

public class TechActivity extends AppCompatActivity {
    private TechViewModel viewModel;
    private TextInputLayout titleTextInputLayout;
    private TextInputLayout contentTextInputLayout;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tech);

        titleTextInputLayout = findViewById(R.id.activity_tech_title_text_input_layout);
        contentTextInputLayout = findViewById(R.id.activity_tech_content_text_input_layout);

        NewsService newsService = MemoryNewsService.getInstance();

        TechViewModelFactory factory = new TechViewModelFactory(newsService);

        viewModel = new ViewModelProvider(this, factory).get(TechViewModel.class);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_tech_options_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.activity_tech_options_menu_save:
                saveNews();
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    private void saveNews() {
        Maybe<News> maybeNews = getNews();

        if (!maybeNews.hasValue()) {
            Toast.makeText(this, "Enter all data", Toast.LENGTH_SHORT).show();
            return;
        }

        News news = maybeNews.getValue();

        viewModel.save(news).observe(this, (result) -> {
            if (result.isFailure()) {
                Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
                return;
            }

            finish();
        });
    }

    private Maybe<News> getNews() {
        String title = titleTextInputLayout.getEditText().getText().toString();
        String content = contentTextInputLayout.getEditText().getText().toString();

        if (title.isEmpty()) {
            return Maybe.empty();
        }

        if (content.isEmpty()) {
            return Maybe.empty();
        }

        News news = new News(UUID.randomUUID(), title, content);

        return Maybe.of(news);
    }
}
