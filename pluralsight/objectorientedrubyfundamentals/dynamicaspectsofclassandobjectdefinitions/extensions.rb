module Extensions
    refine String do
        def titelize
            split.map {|it| it.capitalize}.join ' '
        end
    end
end
