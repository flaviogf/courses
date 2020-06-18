package br.com.flaviogf.technews.fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import java.util.UUID;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.infrastructure.Maybe;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.repositories.MemoryNewsRepository;
import br.com.flaviogf.technews.repositories.NewsRepository;
import br.com.flaviogf.technews.viewmodels.NewsViewModel;
import br.com.flaviogf.technews.viewmodels.NewsViewModelFactory;

public class NewsFragment extends Fragment {
    private NewsViewModel viewModel;
    private EditText idEditText;
    private EditText titleEditText;
    private EditText contentEditText;
    private OnOptionsItemDoneSelectedListener onOptionsItemDoneSelectedListener;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);

        NewsRepository newsRepository = new MemoryNewsRepository();

        NewsViewModelFactory factory = new NewsViewModelFactory(newsRepository);

        viewModel = new ViewModelProvider(this, factory).get(NewsViewModel.class);
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_news, container, false);

        idEditText = view.findViewById(R.id.fragment_news_id_edit_text);
        titleEditText = view.findViewById(R.id.fragment_news_title_edit_text);
        contentEditText = view.findViewById(R.id.fragment_news_content_edit_text);

        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        fillFields();
    }

    @Override
    public void onCreateOptionsMenu(@NonNull Menu menu, @NonNull MenuInflater inflater) {
        super.onCreateOptionsMenu(menu, inflater);
        inflater.inflate(R.menu.news_options_menu, menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.news_options_menu_done:
                saveNews();
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    public void setOnOptionsItemDoneSelectedListener(OnOptionsItemDoneSelectedListener onOptionsItemDoneSelectedListener) {
        this.onOptionsItemDoneSelectedListener = onOptionsItemDoneSelectedListener;
    }

    private void fillFields() {
        Bundle arguments = getArguments();

        if (arguments == null) {
            idEditText.setText(UUID.randomUUID().toString());
            return;
        }

        String id = arguments.getString("@news-id");

        if (id == null) {
            idEditText.setText(UUID.randomUUID().toString());
            return;
        }

        viewModel.fetchOne(id).observe(this, (result) -> {
            if (result.isFailure()) {
                idEditText.setText(UUID.randomUUID().toString());
                return;
            }

            News news = result.getValue();

            idEditText.setText(news.getId());
            titleEditText.setText(news.getTitle());
            contentEditText.setText(news.getContent());
        });
    }

    private void saveNews() {
        Maybe<News> maybeNews = getNews();

        if (!maybeNews.hasValue()) {
            Toast.makeText(getContext(), "Enter all data", Toast.LENGTH_SHORT).show();
            return;
        }

        News news = maybeNews.getValue();

        viewModel.save(news).observe(this, (result) -> {
            if (result.isFailure()) {
                Toast.makeText(getContext(), result.getMessage(), Toast.LENGTH_SHORT).show();
                return;
            }

            onOptionsItemDoneSelectedListener.onSelect();
        });
    }

    private Maybe<News> getNews() {
        String id = idEditText.getText().toString();
        String title = titleEditText.getText().toString();
        String content = contentEditText.getText().toString();

        if (id.isEmpty()) {
            return Maybe.empty();
        }

        if (title.isEmpty()) {
            return Maybe.empty();
        }

        if (content.isEmpty()) {
            return Maybe.empty();
        }

        News news = new News(id, title, content);

        return Maybe.of(news);
    }

    public interface OnOptionsItemDoneSelectedListener {
        void onSelect();
    }
}
