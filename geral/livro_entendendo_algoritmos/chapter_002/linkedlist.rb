class Node
    attr_accessor :value, :before, :after

    def initialize(value, before, after)
        @value = value
        @before = before
        @after = after
    end

end

class LinkedList
    attr_accessor :head, :tail

    def add(value)
        if @head == nil
            node = Node.new(value, nil, nil)
            @head = node
            @tail = node
        else
            node = Node.new(value, nil, @head)
            @head.before = node
            @head = node
        end
    end

    def remove()
        if @tail and @tail.before
            @tail.before.after = nil
        end

        @tail = @tail.before

        if not @tail
            @head = nil
        end
    end

    def print()
        current = @head

        puts "***"

        puts "Head: #{@head&.value}"

        puts "Tail: #{@tail&.value}"

        while current != nil

            puts current.value

            current = current.after
        end
    end
end

list = LinkedList.new()

list.add 10

list.add 20

list.add 30

list.add 40

list.add 50

list.print

list.remove

list.remove

list.print

list.remove

list.remove

list.print

list.remove

list.print
