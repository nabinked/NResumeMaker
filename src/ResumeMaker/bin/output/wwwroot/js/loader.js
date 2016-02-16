 $(document).ready(function() {
    (function() {
      $.fn.loader = function(options) {
        var element, settings, style;

        settings = $.extend({
          boxes: 5,
          dimensions: 6,
          radius: 25,
          interval: 3000,
          color: '#FFF'
        }, options);
        this.each(function() {
          var animate, container, i, intr, me, _fn, _i, _ref;

          me = $(this);
          me.height(settings.dimensions + 4).width('100%').css('overflow', 'hidden').css('display', 'block');
          if ($('.box', me).length !== settings.boxes) {
            $('.box-container', me).remove();
            container = $('<div class="box-container"></div>');
            me.append(container);
            _fn = function() {
              return container.append($('<div class="box"></div>'));
            };
            for (i = _i = 1, _ref = settings.boxes; 1 <= _ref ? _i <= _ref : _i >= _ref; i = 1 <= _ref ? ++_i : --_i) {
              _fn();
            }
          }
          animate = function() {
            var boxes_width, container_width, spacing;

            if (me.data('stop')) {
              return false;
            }
            me.data('stop', false);
            me.data('done', false);
            container = $('.box-container', me);
            container_width = me.width() / 2;
            container.width(container_width);
            container.css('position', 'relative');
            boxes_width = settings.dimensions * settings.boxes;
            spacing = (container_width - boxes_width) / settings.boxes;
            container.css('left', container_width * -1);
            $('.box', container).css('margin-left', spacing);
            container.animate({
              'margin-left': container_width * 2 - boxes_width
            }, settings.interval, 'swing', function() {
              container.animate({
                'margin-left': container_width * 3
              }, settings.interval, 'swing', function() {
                container.css('margin-left', '0px');
                me.data('done', true);
                return animate();
              });
              return $('.box', container).animate({
                'margin-left': spacing
              }, settings.interval, 'swing');
            });
            $('.box', container).animate({
              'margin-left': 0
            }, settings.interval, 'swing');
            return true;
          };
          if (!animate()) {
            return intr = setInterval(function() {
              if (me.data('done')) {
                me.data('stop', false);
                animate();
                return clearInterval(intr);
              }
            }, 1000);
          }
        });
        style = '.box-container {clear:both;overflow:hidden}\r\n.box {display:inline-block; float: left; width:' + settings.dimensions + 'px;height:' + settings.dimensions + 'px; background-color:' + settings.color + ';border:2px solid ' + settings.color + ';border-radius:' + settings.radius + 'px;}';
        if ($("[data-tag='loader']", $('head')).length === 0) {
          element = document.createElement('style');
          $(element).attr('type', 'text/css');
          $(element).attr('data-tag', 'loader');
          if (element.styleSheet) {
            element.styleSheet.cssText = style;
          } else {
            $(element).html(style);
          }
          return $('head').append(element);
        }
      };
      return this;
    })(jQuery);
    (function() {
      return $.fn.clearLoader = function(options) {
        return this.each(function() {
          var me;

          me = $(this);
          me.data('stop', true);
          return me.hide();
        });
      };
    })(jQuery);
  });