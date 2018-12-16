<?php for($i = 0; $i < 3; $i++) {?>
    <article>
        <header>
            <h1>Lorem ipsum dolor sit <?php echo $i ?></h1>
            <h2>por Jonas Hirata</h2>
        </header>

        <div class="article-text">
            <figure>
                <img
                    src="img/paisagem.jpg"
                    title="Paisagem"
                    alt="Árvores ao redor de um lago">
                <figcaption>Árvores ao redor de um lago</figcaption>
            </figure>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Deleniti vel voluptas, necessitatibus numquam iure sed voluptates reiciendis obcaecati minus delectus aliquid debitis suscipit, dolore nisi repellendus laborum ab perferendis dolor.</p>
        </div>

        <div class="article-comments">
            <input
                class="show-comments"
                type="button"
                value="Comentar/Exibir comentários">

            <form>
                <fieldset>
                    <legend>Deixe o seu comentario</legend>
                    <input type="text" placeholder="Nome">
                    <input type="email" placeholder="E-mail">
                    <textarea placeholder="Comentários"></textarea>
                    <input type="submit" value="Enviar">
                </fieldset>
            </form>

            <article>
                <small>Jonas Hirata</small>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Temporibus est aperiam ea praesentium voluptatibus ut, optio, aut. Voluptatem vel, dolorum soluta quos repellat, esse reiciendis sed exercitationem dicta veritatis fugiat.</p>
            </article>
        </div>
    </article>
<?php }; ?>
